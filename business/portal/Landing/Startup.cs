using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Nmro.Hosting.ServiceDiscovery;
using Nmro.Hosting.OidcClients;
using Nmro.Hosting;
using Elastic.Apm.NetCoreAll;

namespace Nmro.Portal.Landing
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            Environment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if(Environment.IsDevelopment()){
                IdentityModelEventSource.ShowPII = true;
            }

            services.AddNmroLogging();

            services.AddControllersWithViews();

            services.AddControllers();

            services.AddOidcHybridAuthentication(Configuration);

            services.AddHealthChecks();

            services.RegisterConsulServices(
                Program.AppName,
                option => Configuration.GetSection("ServiceDiscovery").Bind(option)
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
                app.UseExceptionHandler("/Home/Error");
                // https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                app.UseHttpsRedirection();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseHealthChecks("/hc");
        }
    }
}
