using System;
using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nmro.BuildingBlocks.Web.ServiceDiscovery
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterConsulServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationOptions options = configuration.GetServiceDiscoveryOptions();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var consulClient = CreateConsulClient(options);

            services.AddSingleton(options);
            services.AddSingleton<IConsulClient, ConsulClient>(p => consulClient);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
        }

        private static ConsulClient CreateConsulClient(ConfigurationOptions serviceConfig)
        {
            return new ConsulClient(config =>
            {
                config.Address = serviceConfig.DiscoveryAddress;
            });
        }
    }
}
