using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public DeleteCountryCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.Id);
            }

            _context.Countries.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
