using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Application.Models.Notifications.Commands.CreateNotification;
using DieteticSNS.Domain.Entities;
using DieteticSNS.Domain.Enumerations;
using MediatR;

namespace DieteticSNS.Application.Models.Followings.Commands.UnfollowUser
{
    public class UnfollowUserCommandHandler : IRequestHandler<UnfollowUserCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMediator _mediator;

        public UnfollowUserCommandHandler(IDieteticSNSDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(UnfollowUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Followings
                .Where(x => x.UserId == request.UserId && x.FollowerId == request.FollowerId) 
                .FirstOrDefault();

            if (entity == null)
            {
                throw new NotFoundException(nameof(Following), $"UserId: { request.UserId }, FollowerId: { request.FollowerId }");
            }

            _context.Followings.Remove(entity);

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
                            NotificationType = NotificationType.UserUnfollowing
                        };

                        await _mediator.Send(command);
                    }
                }
            }

            return Unit.Value;
        }
    }
}
