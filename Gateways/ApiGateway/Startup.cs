using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nmro.ApiGateway.Extentions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

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
                 
            services.AddOcelot();
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHealthChecks("/hc");

            app.UseOcelot().Wait();

        }
    }
}
