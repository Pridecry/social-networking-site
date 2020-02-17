using AutoMapper;
using DieteticSNS.Persistence;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Tests.Infrastructure
{
    public class ServicesModel
    {
        public DieteticSNSDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public IConfiguration Configuration { get; set; }
    }
}
