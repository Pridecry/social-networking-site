using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.DeletePostReports
{
    public class DeletePostReportsCommandHandler : IRequestHandler<DeletePostReportsCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public DeletePostReportsCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePostReportsCommand request, CancellationToken cancellationToken)
        {
            var entities = _context.PostReports.Where(x => x.PostId == request.Id).ToList();

            if (entities == null)
            {
                throw new NotFoundException(nameof(CommentReport), request.Id);
            }

            foreach (var entity in entities)
            {
                _context.PostReports.Remove(entity);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
