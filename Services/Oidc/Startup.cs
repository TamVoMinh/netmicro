using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nmro.Web.ServiceDiscovery;
using Nmro.Oidc.Application;
using Nmro.Common;
using Nmro.Web;

namespace Nmro.Oidc
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
            services.AddNmroLogging();

            services.Configure<AppSettings>(Configuration);

            services.AddCors(options => AllOrigins.SetUpPolicy(options));


            services.AddUserStore();

            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddIdentityServer4Stores(Configuration);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("RedisConnection");
                options.InstanceName = Program.AppName;
            });

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();

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
            else
            {
                //see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCors(AllOrigins.PolicyName);

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
