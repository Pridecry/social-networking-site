using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DieteticSNS.Application.System.Commands.SeedData
{
    public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public SeedDataCommandHandler(IDieteticSNSDbContext context, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new DataSeeder(_context, _roleManager);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
