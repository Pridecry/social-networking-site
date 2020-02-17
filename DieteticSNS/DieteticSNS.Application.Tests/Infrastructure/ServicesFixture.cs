using System;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Persistence;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace DieteticSNS.Application.Tests.Infrastructure
{
    public class ServicesFixture : IDisposable
    {
        public DieteticSNSDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public ServicesFixture()
        {
            var servicesModel = ServicesFactory.Create();

            Context = servicesModel.Context;
            Mapper = servicesModel.Mapper;
            Configuration = servicesModel.Configuration;
        }

        public void Dispose()
        {
            DieteticSNSContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("ServicesTestCollection")]
    public class ServicesCollection : ICollectionFixture<ServicesFixture> { }
}
