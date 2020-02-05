using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Followings.Commands.FollowUser
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;

        public FollowUserCommandHandler(IDieteticSNSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Following>(request);

            _context.Followings.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
