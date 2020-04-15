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
using System.Text;

namespace Nmro.Web.ServiceDiscovery
{
    public class ServiceDiscoveryHostedService : IHostedService
    {
        private const int DefaultHttpPort = 80;
        private readonly IConsulClient _client;
        private readonly DiscoveryOptions _config;

        private readonly ServiceMetaData _meta;
        private readonly string _registrationId;
        private readonly System.Net.IPAddress _ipv4;
        ILogger<ServiceDiscoveryHostedService> _logger;

        public ServiceDiscoveryHostedService(
            ILogger<ServiceDiscoveryHostedService> logger,
            IConsulClient client,
            DiscoveryOptions config,
            ServiceMetaData meta
        )
        {
            _client = client;
            _config = config;
            _meta = meta;
            _logger = logger;
            _ipv4 = ResolveLanIPV4() ?? throw new Exception("Not Found V4 IP");
            _registrationId = string.Format("{0}-[{1}:{2}]", _config.ServiceName, _ipv4, _config.ServicePort);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            AsyncRetryPolicy policy = CreatePolicy(_logger, nameof(ServiceDiscoveryHostedService));

            await policy.ExecuteAsync(async ()=> {
                var registration = new AgentServiceRegistration
                {
                    ID = _registrationId,
                    Address = _ipv4.ToString(),
                    Name = _config.ServiceName,
                    Port = _config.ServicePort,
                    Check = new AgentServiceCheck{
                        Interval = new TimeSpan(0,0,5),
                        DeregisterCriticalServiceAfter = new TimeSpan(0, 0, 25),
                        Timeout = new TimeSpan(0,0,1),
                        HTTP= string.Format(
                            "http://{0}{1}/{2}",
                            _config.ServiceName,
                            _config.ServicePort != DefaultHttpPort ? $":{_config.ServicePort}" : string.Empty,
                            _config.HealthPath
                        )
                    },
                    Meta = _meta
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
