using IdentityServer4.Validation;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Nmro.Oidc.Services;
using Nmro.Oidc.Storage;
using Serilog;
using System;
using Nmro.Oidc.Extensions;
using IdentityServer4.Services;
using Nmro.Oidc.Application;

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
                //.AddInMemoryClients(Storage.Clients.Get())
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourceStore>()
                //.AddInMemoryIdentityResources(Storage.Resources.GetIdentityResources())
                //.AddInMemoryApiResources(Storage.Resources.GetApiResources())
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
