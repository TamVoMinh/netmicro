using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using Nmro.ApiGateway.Extentions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Nmro.BuildingBlocks.Web.ServiceDiscovery;

namespace Nmro.ApiGateway
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

            services.AddCors(options =>{
                options.AddPolicy(Configuration.GetCorsPolicyName(), corsPolicy =>{
                    corsPolicy.WithOrigins(Configuration.GetAllowOrigns());
                    corsPolicy.AllowAnyHeader();
                    corsPolicy.AllowAnyMethod();
                });
            });

            services.AddOcelot();
            services.AddHealthChecks();

            services.RegisterConsulServices(Program.AppName, Configuration);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(Configuration.GetCorsPolicyName());

            app.UseRouting();

            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseOcelot().Wait();

        }
    }
}
