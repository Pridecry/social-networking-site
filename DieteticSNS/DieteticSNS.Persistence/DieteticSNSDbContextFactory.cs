using Microsoft.EntityFrameworkCore;
using Northwind.Persistence.Infrastructure;

namespace DieteticSNS.Persistence
{
    class DieteticSNSDbContextFactory : DesignTimeDbContextFactoryBase<DieteticSNSDbContext>
    {
        protected override DieteticSNSDbContext CreateNewInstance(DbContextOptions<DieteticSNSDbContext> options)
        {
            return new DieteticSNSDbContext(options);
        }
    }
}
