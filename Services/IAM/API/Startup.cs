using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Nmro.Web.ServiceDiscovery;
using Nmro.IAM.Persistence;
using Nmro.IAM.Application;
using Nmro.Common;
using Nmro.Web;

namespace Nmro.IAM.API
{
    public class Startup
    {
        public const string PathBase = "/iam";
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            Environment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddCors(options => AllOrigins.SetUpPolicy(options));
            }

            services
                .AddNmroLogging()
                .AddCommonServices()
                .AddWebServices()
                .AddPersistance(Configuration)
                .AddApplication()
                .AddSwagger();

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

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
                app.UseCors(AllOrigins.PolicyName);
            }

            app.UsePathBase(PathBase);

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "oas/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = PathBase, Description = "Identity Accesss Managerment" } };
                });
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
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
