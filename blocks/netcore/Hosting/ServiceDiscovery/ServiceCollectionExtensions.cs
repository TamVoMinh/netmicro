using System;
using Consul;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nmro.Hosting.ServiceDiscovery
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterConsulServices(this IServiceCollection services, string serviceName, Action<DiscoveryOptions> configOptions, Action<ServiceMetaData> configMeta = null)
            => services.RegisterConsulServices(BuilOption(configOptions, serviceName), buildMeta(configMeta));


        private static IServiceCollection RegisterConsulServices(this IServiceCollection services, DiscoveryOptions discoveryOptions, ServiceMetaData serviceMetaData)
        {
            if (discoveryOptions == null)
            {
                throw new ArgumentNullException(nameof(discoveryOptions));
            }

            var consulClient = CreateConsulClient(discoveryOptions.DiscoveryAddress);

            services.AddSingleton(discoveryOptions);
            services.AddSingleton(serviceMetaData ?? new ServiceMetaData());
            services.AddSingleton<IConsulClient, ConsulClient>(p => consulClient);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();

            return services;
        }

        private static DiscoveryOptions BuilOption(Action<DiscoveryOptions> build, string serviceName){
            if(string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentNullException("serviceName");
            }

            var options = new DiscoveryOptions();
            build(options);
            options.ServiceName = serviceName;
            return options;
        }

        private static ServiceMetaData buildMeta(Action<ServiceMetaData> build){
            if(build == null) return null;
            ServiceMetaData meta = new ServiceMetaData();
            build(meta);
            return meta;
        }

        private static ConsulClient CreateConsulClient(string discoveryAddress)
            => new ConsulClient(config => config.Address = new Uri(discoveryAddress));

    }
}
