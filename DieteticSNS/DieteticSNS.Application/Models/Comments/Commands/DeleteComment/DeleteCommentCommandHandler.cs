using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public DeleteCommentCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }

            _context.Comments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
