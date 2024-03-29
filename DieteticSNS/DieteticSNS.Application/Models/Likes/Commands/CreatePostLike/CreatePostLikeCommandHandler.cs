﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Application.Models.Notifications.Commands.CreateNotification;
using DieteticSNS.Domain.Entities;
using DieteticSNS.Domain.Enumerations;
using MediatR;

namespace DieteticSNS.Application.Models.Likes.Commands.CreatePostLike
{
    public class CreatePostLikeCommandHandler : IRequestHandler<CreatePostLikeCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IWallService _wallService;
        private readonly IMediator _mediator;

        public CreatePostLikeCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService, IWallService wallService, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _wallService = wallService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreatePostLikeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PostLike>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            _context.PostLikes.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                var item = _context.PostLikes
                    .Where(x => x.PostId == entity.PostId && x.UserId == entity.UserId && x.CreatedAt == entity.CreatedAt)
                    .FirstOrDefault();

                await _wallService.SendPostLike(entity.UserId, item.Id, item.PostId);

                var recipientId = _context.Posts.Find(entity.PostId)?.UserId;

                if (recipientId != null)
                {
                    var setting = _context.UserNotificationSettings
                        .Where(x => x.UserId == recipientId)
                        .FirstOrDefault()
                        .PostLikes;

                    if (setting)
                    {
                        if (entity.UserId != recipientId)
                        {
                            var command = new CreateNotificationCommand
                            {
                                UserId = entity.UserId,
                                RecipientId = recipientId.Value,
                                NotificationType = NotificationType.PostLike
                            };

                            await _mediator.Send(command);
                        }
                    }
                }
            }

            return Unit.Value;
        }
    }
}
