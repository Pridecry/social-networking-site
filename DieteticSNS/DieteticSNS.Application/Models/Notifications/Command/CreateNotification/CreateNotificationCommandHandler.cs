using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Application.Models.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public CreateNotificationCommandHandler(IDieteticSNSDbContext context, IMapper mapper, INotificationService notificationService)
        {
            _context = context;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Notification>(request);

            _context.Notifications.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                var item = _context.Notifications
                    .Where(x => x.UserId == entity.UserId) 
                    .Where(x => x.RecipientId == entity.RecipientId)
                    .Where(x => x.CreatedAt == entity.CreatedAt)
                    .Include(x => x.User)
                    .FirstOrDefault();

                var notification = _mapper.Map<UnreadNotificationDto>(item);

                await _notificationService.SendNotification(notification);
            }

            return Unit.Value;
        }
    }
}
