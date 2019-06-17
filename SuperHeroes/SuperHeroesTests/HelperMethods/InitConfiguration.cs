using System;
using Microsoft.Extensions.Configuration;

namespace SuperHeroesUnitTests.HelperMethods
{
    public class InitConfiguration
    {
        public static IConfiguration GetSettings()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }
}
