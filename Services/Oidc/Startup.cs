using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nmro.Oidc.Services;
using Serilog;
using System;
using Nmro.Oidc.Application;
using Nmro.BuildingBlocks.Web.ServiceDiscovery;
using Nmro.Oidc.Storage;

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

        // This method gets called by the runtime. Use this method to add services to the container.
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

            services
                .AddIdentityServer()
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourceStore>()
                .AddDeveloperSigningCredential();

            services.AddHttpClient("iam", opts =>
            {
                opts.BaseAddress = new Uri(Configuration.GetValue<string>("IdentityApiEndpoint") ?? "http://iam-api/iam");
            });

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "OidcInstance";
            });

            // Register services
            services.AddScoped<IUserService, UserService>();

            services.AddHealthChecks();

            services.RegisterConsulServices(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
