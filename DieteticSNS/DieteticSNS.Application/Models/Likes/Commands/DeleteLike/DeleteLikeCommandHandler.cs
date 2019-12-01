using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Likes.Commands.DeleteLike
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public DeleteLikeCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Likes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Like), request.Id);
            }

            _context.Likes.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
