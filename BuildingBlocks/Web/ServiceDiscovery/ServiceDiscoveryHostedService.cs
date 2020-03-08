using System;
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
        private string _registrationId;
        ILogger<ServiceDiscoveryHostedService> _logger;

        public ServiceDiscoveryHostedService(ILogger<ServiceDiscoveryHostedService> logger,IConsulClient client, ConfigurationOptions config)
        {
            _client = client;
            _config = config;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            AsyncRetryPolicy policy = CreatePolicy(_logger, nameof(ServiceDiscoveryHostedService));

            await policy.ExecuteAsync(async ()=> {
                 _registrationId = $"{_config.ServiceName}-{_config.ServiceId}";

                var registration = new AgentServiceRegistration
                {
                    ID = _registrationId,
                    Name = _config.ServiceName,
                    Address = _config.ServiceAddress.Host,
                    Port = _config.ServiceAddress.Port
                };

                await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
                await _client.Agent.ServiceRegister(registration, cancellationToken);
            });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            AsyncRetryPolicy policy = CreatePolicy(_logger, nameof(ServiceDiscoveryHostedService));
            await policy.ExecuteAsync(async ()=> {
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
    }
}
