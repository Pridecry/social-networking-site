using DieteticSNS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DieteticSNS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DieteticSNSDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DieteticSNSDatabase")));

            services.AddScoped<IDieteticSNSDbContext>(provider => provider.GetService<DieteticSNSDbContext>());

            return services;
        }
    }
}
