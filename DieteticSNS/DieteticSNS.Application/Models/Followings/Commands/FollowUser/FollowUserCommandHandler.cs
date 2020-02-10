using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Application.Models.Notifications.Commands.CreateNotification;
using DieteticSNS.Domain.Entities;
using DieteticSNS.Domain.Enumerations;
using MediatR;

namespace DieteticSNS.Application.Models.Followings.Commands.FollowUser
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FollowUserCommandHandler(IDieteticSNSDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Following>(request);

            _context.Followings.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                var setting = _context.UserNotificationSettings
                        .Where(x => x.UserId == entity.FollowerId)
                        .FirstOrDefault()
                        .UserFollowings;

                if (setting)
                {
                    if (entity.FollowerId != entity.UserId)
                    {
                        var command = new CreateNotificationCommand
                        {
                            UserId = entity.FollowerId,
                            RecipientId = entity.UserId,
                            NotificationType = NotificationType.UserFollowing
                        };

                        await _mediator.Send(command);
                    }
                }
            }

            return Unit.Value;
        }
    }
}
