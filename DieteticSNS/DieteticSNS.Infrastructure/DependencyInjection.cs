using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.WebUI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DieteticSNS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();

            return services;
        }
    }
}
