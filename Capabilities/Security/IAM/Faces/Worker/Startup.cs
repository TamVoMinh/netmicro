using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hangfire;
using Hangfire.PostgreSql;
using Elastic.Apm.NetCoreAll;
using Nmro.Security.IAM.Infras.Storage;
using Nmro.Security.IAM.Core;
using Nmro.Security.IAM.Faces.Worker.Crontab;

namespace Nmro.Security.IAM.Faces.Worker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddPersistance(Configuration)
                .AddCore();

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection"))
            );

            services.AddHangfireServer();

            services.AddRecurringJobs();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAllElasticApm(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHangfireDashboard("/hangfire");
            }

            app.UseHangfireServer();
        }
    }
}
