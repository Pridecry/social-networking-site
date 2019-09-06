using System;
using DieteticSNS.Persistence;

namespace DieteticSNS.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public DieteticSNSDbContext Context { get; private set; }
        //public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = DieteticSNSContextFactory.Create();
            //Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            DieteticSNSContextFactory.Destroy(Context);
        }
    }
}
