using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nmro.IAM.Application;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAMDbcontext>(options => {
                options.UseNpgsql(configuration.GetConnectionString(Constants.ConnectionStringName));
            });

            services.AddScoped<IIAMDbcontext>(provider => provider.GetService<IAMDbcontext>());
            services.AddScoped<IPasswordProcessor, PasswordProcessor>();

            return services;
        }
    }
}

