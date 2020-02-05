using System.Collections.Generic;
using System.Globalization;
using DieteticSNS.Application;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Infrastructure;
using DieteticSNS.Infrastructure.Hubs;
using DieteticSNS.Persistence;
using DieteticSNS.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DieteticSNS.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.AddSignalR();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
                options.RequestCultureProviders = new List<IRequestCultureProvider>();
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IDieteticSNSDbContext>())
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notificationHub");
                endpoints.MapHub<WallHub>("/wallHub");

                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "/Error",
                    defaults: new { controller = "Home", action = "Error" });
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "/GetStarted",
                    defaults: new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Posts", action = "GetPostList" });
            });
        }
    }
}
