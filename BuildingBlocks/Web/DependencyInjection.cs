using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nmro.Web.Services;
using Serilog;

namespace Nmro.Web
{
    public static class DependencyInjection
    {
         public static IServiceCollection AddNmroLogging(this IServiceCollection services)
            =>  services.AddLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddSerilog(dispose: true);
                });

        public static IServiceCollection AddWebServices(this IServiceCollection services)
            => services
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddHttpContextAccessor();
    }

}
