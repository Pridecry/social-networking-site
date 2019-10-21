using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using MediatR;

namespace DieteticSNS.Application.System.Commands.SeedData
{
    public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public SeedDataCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new DataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
