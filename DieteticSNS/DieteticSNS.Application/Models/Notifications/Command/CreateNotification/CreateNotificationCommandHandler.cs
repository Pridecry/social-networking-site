using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(IDieteticSNSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Notification>(request);

            _context.Notifications.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
