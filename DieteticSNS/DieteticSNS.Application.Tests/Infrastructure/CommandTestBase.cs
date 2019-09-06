using System;
using DieteticSNS.Persistence;

namespace DieteticSNS.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly DieteticSNSDbContext _context;

        public CommandTestBase()
        {
            _context = DieteticSNSContextFactory.Create();
        }

        public void Dispose()
        {
            DieteticSNSContextFactory.Destroy(_context);
        }
    }
}
