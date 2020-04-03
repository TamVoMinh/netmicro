using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using Nmro.ApiGateway.Extentions;
using Nmro.Web.ServiceDiscovery;
using Nmro.Common.Extentions;
using IdentityServer4.AccessTokenValidation;

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
            IdentityModelEventSource.ShowPII = true;

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

            services
                .AddAuthentication()
                .AddJwtBearer("AuthN", options=>{
                    //TODO Apply Extention & Configuration options
                    options.Authority=  Configuration.GetValue<string>("IdentityUrl") ?? "http://oidc.nmro.local";
                    options.Audience="member";
                    options.RequireHttpsMetadata = false;
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseOcelot().Wait();

        }
    }
}
