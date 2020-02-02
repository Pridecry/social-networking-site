using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.DeleteCommentReports
{
    public class DeleteCommentReportsCommandHandler : IRequestHandler<DeleteCommentReportsCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public DeleteCommentReportsCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentReportsCommand request, CancellationToken cancellationToken)
        {
            var entities = _context.CommentReports.Where(x => x.CommentId == request.Id).ToList();

            if (entities == null)
            {
                throw new NotFoundException(nameof(CommentReport), request.Id);
            }

            foreach (var entity in entities)
            {
                _context.CommentReports.Remove(entity);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
