using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DieteticSNS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IWallService, WallService>();

            return services;
        }
    }
}
