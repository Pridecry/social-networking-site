using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using MediatR;

namespace DieteticSNS.Application.Models.Notifications.Commands.ReadNotifications
{
    public class ReadNotificationsCommandHandler : IRequestHandler<ReadNotificationsCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly ICurrentUserService _userService;

        public ReadNotificationsCommandHandler(IDieteticSNSDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Unit> Handle(ReadNotificationsCommand request, CancellationToken cancellationToken)
        {
            var id = int.Parse(_userService.GetUserId());

            var entities = _context.Notifications
                .Where(x => x.RecipientId == id && x.IsRead == false).ToList();

            foreach (var entity in entities)
            {
                entity.IsRead = true;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
