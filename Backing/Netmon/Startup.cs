using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Nmro.Web.ServiceDiscovery;
using Nmro.Web.OidcClients;
using Hangfire;
using Hangfire.PostgreSql;
using Elastic.Apm.NetCoreAll;
using System.Collections.Generic;
using Hangfire.Dashboard;

namespace Nmro.Netmon
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
            services.AddLogging(logging => {
                logging.ClearProviders();
                logging.AddSerilog(dispose: true);
            });

            services.AddOidcHybridAuthentication(Configuration);

            services.AddHealthChecks();
            services.AddHealthChecksUI();

            services.RegisterConsulServices(
                Program.AppName,
                option => Configuration.GetSection("ServiceDiscovery").Bind(option)
            );

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection"))
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAllElasticApm(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UsePathBase("/netmon");

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecksUI(options => {
                    options.UIPath = "/health";
                    options.ApiPath = "/health/api";
                    options.ResourcesPath = "/health/resources";
                });
            });
            app.UseHealthChecks("/hc");

            app.UseHangfireDashboard("/hangfire", new DashboardOptions {
                Authorization = new List<IDashboardAuthorizationFilter> {
                    new DashboardAuthorizationFilter()
                },
                AppPath= "/netmon",
                PrefixPath = "/netmon"
            });
        }
    }
}
