using System;
using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nmro.Web.ServiceDiscovery
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterConsulServices(this IServiceCollection services, string appName,IConfiguration configuration)
        {
            if(string.IsNullOrEmpty(appName))
            {
                throw new ArgumentNullException("appName", "Must have value");
            }

            ConfigurationOptions options = configuration.GetServiceDiscoveryOptions(appName);
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
