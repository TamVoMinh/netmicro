using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Application.UseCases.PersistedGrants.Commands;

namespace Nmro.IAM.Worker.Crontab
{
    public class CronTabService : IHostedService
    {
        private readonly IMediator  _mediator;
        private readonly ILogger<CronTabService> _logger;

        public CronTabService(IMediator  mediator, ILogger<CronTabService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Add RecurringJob: IAM.Grants.CleanUp");
            RecurringJob.AddOrUpdate(
                "IAM.Grants.CleanUp",
                () => _mediator.Send(new CleanUpGrantsCommand(), cancellationToken),
                "*/2 * * * *" // every 2 minutes
            );
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Graceful Shutdown: CronTabService");
            return Task.CompletedTask;
        }
    }
}
