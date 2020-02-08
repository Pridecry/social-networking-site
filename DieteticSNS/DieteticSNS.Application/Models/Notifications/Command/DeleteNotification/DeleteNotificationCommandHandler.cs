using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public DeleteNotificationCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Notifications.Find(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Notification), request.Id);
            }

            _context.Notifications.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
