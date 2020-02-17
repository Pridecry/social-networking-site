using System;
using DieteticSNS.Domain.Entities;
using DieteticSNS.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Application.Tests.Infrastructure
{
    public class DieteticSNSContextFactory
    {
        public static DieteticSNSDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DieteticSNSDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DieteticSNSDbContext(options);

            context.Database.EnsureCreated();

            context.Countries.AddRange(AddCountriesToDatabase());

            context.SaveChanges();

            return context;
        }

        public static void Destroy(DieteticSNSDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }

        private static Country[] AddCountriesToDatabase()
        {
            int countiresCount = 10;
            var countires = new Country[countiresCount];

            for (int i = 0; i < countiresCount; i++)
            {
                countires[i] = new Country
                {
                    Name = $"Name{i}"
                };
            }

            return countires;
        }
    }
}
