using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Nmro.ApiGateway.Extentions;
using Nmro.Web.ServiceDiscovery;
using Nmro.Web;

namespace Nmro.ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment  {get;}

        public void ConfigureServices(IServiceCollection services)
        {
            if(Environment.IsDevelopment()){
                IdentityModelEventSource.ShowPII = true;
            }

            services.AddNmroLogging();
            services.AddCors(options => LimitedOrigins.Bind(
                options,
                Configuration.GetSection("CorsPolicy").Get<CorsPolicyConfigOptions>()
            ));

            services.AddOidcAuthentication(option => Configuration.GetSection("oauth2").Bind(option));

            services.AddOcelot();
            services.AddHealthChecks();

            services.RegisterConsulServices(
                Program.AppName,
                option => Configuration.GetSection("ServiceDiscovery").Bind(option)
            );

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(Configuration.GetValue<string>("CorsPolicy:PolicyName"));

            app.UseRouting();

            app.UseHealthChecks("/health");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseOcelot().Wait();

        }
    }
}
