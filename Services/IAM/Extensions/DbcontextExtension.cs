using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nmro.IAM.Reposistory;
public static class IAMDbcontextExtension
    {
        public static IServiceCollection AddIAMDbcontext(this IServiceCollection services, string connectionString, string migrationsAssembly)
        {
            services.AddDbContext<IAMDbcontext>(options => {
                options.UseNpgsql(connectionString, optionsBuilder => optionsBuilder.MigrationsAssembly(migrationsAssembly));
            });
            return services;
        }
    }
