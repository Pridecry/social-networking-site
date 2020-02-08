using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using MediatR;

namespace DieteticSNS.Application.Models.Notifications.Commands.DeleteAllNotifications
{
    public class DeleteAllNotificationsCommandHandler : IRequestHandler<DeleteAllNotificationsCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly ICurrentUserService _userService;

        public DeleteAllNotificationsCommandHandler(IDieteticSNSDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Unit> Handle(DeleteAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            var id = int.Parse(_userService.GetUserId());

            var entities = _context.Notifications
                .Where(x => x.RecipientId == id).ToList();

            _context.Notifications.RemoveRange(entities);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
