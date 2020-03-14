using System;
using Microsoft.Extensions.Configuration;

namespace Nmro.BuildingBlocks.Web.ServiceDiscovery
{
    public static class ConfigurationExtensions
    {
        public static ConfigurationOptions GetServiceDiscoveryOptions(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new ConfigurationOptions
            {
                DiscoveryAddress = configuration.GetValue<Uri>("ServiceDiscovery:serviceDiscoveryAddress"),
                ServiceName = configuration.GetValue<string>("ServiceDiscovery:serviceName"),
                Port = configuration.GetValue<int>("ServiceDiscovery:port"),
            };

            return serviceConfig;
        }
    }
}
