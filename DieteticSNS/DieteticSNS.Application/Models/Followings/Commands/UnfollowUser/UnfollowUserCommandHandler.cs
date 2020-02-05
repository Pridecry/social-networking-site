using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Followings.Commands.UnfollowUser
{
    public class UnfollowUserCommandHandler : IRequestHandler<UnfollowUserCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public UnfollowUserCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
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

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
