using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<User, IdentityRole<int>>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<DieteticSNSDbContext>();

            return services;
        }
    }
}
