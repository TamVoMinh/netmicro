using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Nmro.Web.ServiceDiscovery;
using Nmro.Oidc.Application;

namespace Nmro.Oidc
{
    public class Startup
    {
        private const string OIDC_CORS_1ST_LAYER_POLICY = "__oidc_cors_1st_layer_policy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog(dispose: true);
            });

            services.Configure<AppSettings>(Configuration);

            services.AddCors(options =>{
                options.AddPolicy(OIDC_CORS_1ST_LAYER_POLICY, corsPolicy =>{
                    corsPolicy.AllowAnyOrigin();
                    corsPolicy.AllowAnyHeader();
                    corsPolicy.AllowAnyMethod();
                });
            });

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

            services.RegisterConsulServices(Program.AppName, Configuration);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCors(OIDC_CORS_1ST_LAYER_POLICY);

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
