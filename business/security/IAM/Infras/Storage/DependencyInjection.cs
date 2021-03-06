using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nmro.Security.IAM.Core.Interfaces;

namespace Nmro.Security.IAM.Infras.Storage
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAMDbcontext>(options => {
                options.UseNpgsql(configuration.GetConnectionString(Constants.ConnectionStringName));
            });

            services.AddScoped<IIAMDbcontext>(provider => provider.GetService<IAMDbcontext>());

            return services;
        }
    }
}

