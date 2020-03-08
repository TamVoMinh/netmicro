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
                ServiceDiscoveryAddress = configuration.GetValue<Uri>("ServiceDiscovery:serviceDiscoveryAddress"),
                ServiceAddress = configuration.GetValue<Uri>("ServiceDiscovery:serviceAddress"),
                ServiceName = configuration.GetValue<string>("ServiceDiscovery:serviceName"),
                ServiceId = configuration.GetValue<string>("ServiceDiscovery:serviceId")
            };

            return serviceConfig;
        }
    }
}
