using System;
using DieteticSNS.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Persistence
{
    public class DieteticSNSDbContextFactory : DesignTimeDbContextFactoryBase<DieteticSNSDbContext>
    {
        protected override DieteticSNSDbContext CreateNewInstance(DbContextOptions<DieteticSNSDbContext> options)
        {
            return new DieteticSNSDbContext(options);
        }

        public static DieteticSNSDbContext Create()
        {
            throw new NotImplementedException();
        }
    }
}
