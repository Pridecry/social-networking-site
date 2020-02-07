using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Account.Commands.UpdateNotifications
{
    public class UpdateNotificationsCommandHandler : IRequestHandler<UpdateNotificationsCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public UpdateNotificationsCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(UpdateNotificationsCommand request, CancellationToken cancellationToken)
        {
            var id = int.Parse(_userService.GetUserId());

            var entity = _context.UserNotificationSettings
                .Where(x => x.UserId == id)
                .FirstOrDefault();

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserNotificationSettings), id);
            }

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
