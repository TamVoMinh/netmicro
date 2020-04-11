using System;
using Consul;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nmro.Web.ServiceDiscovery
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterConsulServices(this IServiceCollection services, string serviceName, Action<DiscoveryOptions> configOptions)
            => services.RegisterConsulServices(BuilOption(configOptions, serviceName));


        private static IServiceCollection RegisterConsulServices(this IServiceCollection services, DiscoveryOptions configOptions)
        {
            if (configOptions == null)
            {
                throw new ArgumentNullException(nameof(configOptions));
            }

            var consulClient = CreateConsulClient(configOptions.DiscoveryAddress);

            services.AddSingleton(configOptions);
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
            Console.WriteLine("options:{0}\n{1}", serviceName, System.Text.Json.JsonSerializer.Serialize(options));
            return options;
        }


        private static ConsulClient CreateConsulClient(string discoveryAddress)
            => new ConsulClient(config => config.Address = new Uri(discoveryAddress));

    }
}
