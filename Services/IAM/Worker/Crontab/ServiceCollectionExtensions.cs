using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nmro.IAM.Worker.Crontab
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecurringJobs(this IServiceCollection services)
            =>  services.AddSingleton<IHostedService, CronTabService>();
    }
}
