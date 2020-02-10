using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Application.Models.Notifications.Commands.CreateNotification;
using DieteticSNS.Domain.Entities;
using DieteticSNS.Domain.Enumerations;
using MediatR;

namespace DieteticSNS.Application.Models.Comments.Commands.CreatePostComment
{
    public class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IWallService _wallService;
        private readonly IMediator _mediator;

        public CreatePostCommentCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService, IWallService wallService, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _wallService = wallService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreatePostCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PostComment>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            _context.PostComments.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                var item = _context.PostComments
                    .Where(x => x.PostId == entity.PostId && x.UserId == entity.UserId && x.CreatedAt == entity.CreatedAt)
                    .FirstOrDefault();

                await _wallService.SendPostComment(entity.UserId, item.Id, item.PostId, item.Content);

                var recipientId = _context.Posts.Find(entity.PostId)?.UserId;

                if (recipientId != null)
                {
                    var setting = _context.UserNotificationSettings
                        .Where(x => x.UserId == recipientId)
                        .FirstOrDefault()
                        .PostComments;

                    if (setting)
                    {
                        if (entity.UserId != recipientId)
                        {
                            var command = new CreateNotificationCommand
                            {
                                UserId = entity.UserId,
                                RecipientId = recipientId.Value,
                                NotificationType = NotificationType.PostComment
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
