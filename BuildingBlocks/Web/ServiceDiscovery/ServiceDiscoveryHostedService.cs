using System;
using System.Linq;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace Nmro.BuildingBlocks.Web.ServiceDiscovery
{
    public class ServiceDiscoveryHostedService : IHostedService
    {
        private readonly IConsulClient _client;
        private readonly ConfigurationOptions _config;
        private readonly string _registrationId;
        private readonly string _ipv4;
        ILogger<ServiceDiscoveryHostedService> _logger;

        public ServiceDiscoveryHostedService(ILogger<ServiceDiscoveryHostedService> logger,IConsulClient client, ConfigurationOptions config)
        {
            _client = client;
            _config = config;
            _logger = logger;

            _registrationId = ResolveHostName();
            _ipv4 = ResolveLanIPV4()?.ToString() ?? "";
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            AsyncRetryPolicy policy = CreatePolicy(_logger, nameof(ServiceDiscoveryHostedService));

            await policy.ExecuteAsync(async ()=> {
                var registration = new AgentServiceRegistration
                {
                    ID = _registrationId,
                    Address = _ipv4,
                    Name = _config.ServiceName,
                    Port = _config.Port
                };

                await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
                await _client.Agent.ServiceRegister(registration, cancellationToken);
            });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            AsyncRetryPolicy policy = CreatePolicy(_logger, nameof(ServiceDiscoveryHostedService));
            await policy.ExecuteAsync(async ()=> {
                _logger.LogInformation("Service Deregister: {name}, {id}", _config.ServiceName, _registrationId);
                await _client.Agent.ServiceDeregister(_registrationId, cancellationToken);
            });
        }

        private AsyncRetryPolicy CreatePolicy(ILogger<ServiceDiscoveryHostedService> logger, string prefix, int retries = 3, int timeInSeconds = 8)
        {
            return Policy.Handle<SystemException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(timeInSeconds),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }

        private System.Net.IPAddress ResolveLanIPV4()
        {
            var firstUpInterface = NetworkInterface.GetAllNetworkInterfaces()
                .OrderByDescending(c => c.Speed)
                .FirstOrDefault(c => c.NetworkInterfaceType != NetworkInterfaceType.Loopback && c.OperationalStatus == OperationalStatus.Up);

            if (firstUpInterface != null)
            {
                var props = firstUpInterface.GetIPProperties();
                var firstIpV4Address = props.UnicastAddresses
                    .Where(c => c.Address.AddressFamily == AddressFamily.InterNetwork)
                    .Select(c => c.Address)
                    .FirstOrDefault();

                return firstIpV4Address;
            }

            return null;
        }

        private string ResolveHostName()
        {
            return System.Net.Dns.GetHostName();
        }
    }
}
