using System;
using Microsoft.Extensions.Configuration;

namespace Nmro.BuildingBlocks.Web.ServiceDiscovery
{
    public static class ConfigurationExtensions
    {
        public static ConfigurationOptions GetServiceDiscoveryOptions(this IConfiguration configuration, string appName)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new ConfigurationOptions
            {
                DiscoveryAddress = configuration.GetValue<Uri>("ServiceDiscovery:ServiceDiscoveryAddress"),
                ServiceName = appName,
                ServicePort = configuration.GetValue<int>("ServiceDiscovery:ServicePort"),
            };

            return serviceConfig;
        }
    }
}
