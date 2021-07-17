using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nmro.Hosting.ServiceDiscovery;
using Nmro.Oidc.Application;
using Nmro.Hosting;
using Elastic.Apm.AspNetCore;
using Elastic.Apm.DiagnosticSource;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.DataProtection;
using StackExchange.Redis;
using System;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

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

            services.ConfigureNonBreakingSameSiteCookies();

            services.Configure<AppSettings>(Configuration);

            services.AddCors(options => AllOrigins.Bind(options));

            services
                .AddDataProtection()
                .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RedisConnection")), "Oidc-DataProtection-Keys");

            services.AddUserStore();

            services
                .AddIdentityServer()
                .AddSigningCredential(new X509Certificate2("oidc.nmro.local.pfx"))
                .AddIdentityServer4Stores(Configuration);

            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddCookie(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                });

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
            app.UseElasticApm(Configuration, new HttpDiagnosticsSubscriber());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllOrigins.PolicyName);

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

            app.UseHealthChecks("/hc");
        }
    }
}
