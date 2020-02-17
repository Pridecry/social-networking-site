using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DieteticSNS.Application.Common.Mappings;
using Microsoft.Extensions.Configuration;
using Moq;

namespace DieteticSNS.Application.Tests.Infrastructure
{
    public class ServicesFactory
    {
        public static ServicesModel Create()
        {
            var context = DieteticSNSContextFactory.Create();
            var mapperMock = new Mock<IMapper>();

            var mapperConfigurationProfiles = new List<Profile>();
            var profiles = typeof(CountriesProfile).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            foreach (var profile in profiles)
            {
                mapperConfigurationProfiles.Add(Activator.CreateInstance(profile) as Profile);
            }

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfiles(mapperConfigurationProfiles));

            var configuration = CreateConfiguration();

            return new ServicesModel
            {
                Context = context,
                Mapper = mapperConfiguration.CreateMapper(),
                Configuration = configuration
            };
        }

        private static IConfiguration CreateConfiguration()
        {
            string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

            var basePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf(".Application")) + ".WebUI";

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{AspNetCoreEnvironment}.json", optional: true)
                .AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
