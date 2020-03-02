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
using Nmro.BuildingBlocks.WebHost.ServiceDiscovery;

namespace Nmro.Oidc
{
    public class Startup
    {
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

            services
                .AddIdentityServer()
                .AddInMemoryClients(Storage.Clients.Get())
                .AddInMemoryIdentityResources(Storage.Resources.GetIdentityResources())
                .AddInMemoryApiResources(Storage.Resources.GetApiResources())
                .AddDeveloperSigningCredential();

            services.AddHttpClient("iam", opts =>
            {
                opts.BaseAddress = new Uri(Configuration.GetValue<string>("IdentityApiEndpoint") ?? "http://iam-api");
            });

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();

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

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseRouting();

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
