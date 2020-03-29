using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Nmro.Web.ServiceDiscovery;
using Nmro.IAM.Persistence;
using Nmro.Blocks.Interfaces;
using Nmro.IAM.API.Services;
using Nmro.IAM.Application;
using Nmro.Blocks.Services;

namespace Nmro.IAM.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            environment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment environment {get;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services
                .AddLogging(logging => {
                    logging.ClearProviders();
                    logging.AddSerilog(dispose: true);
                })
                .AddPersistance(Configuration)
                .AddApplication()
                .AddSwaggerGen(c => {
                    c.EnableAnnotations(true);
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nmro.IAM", Version = "v1" });
                });

            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddScoped<ICurrentUserService, CurrentUserService>()
                    .AddHttpContextAccessor();

            services
                .AddControllers()
                .AddJsonOptions(options=> {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            services.AddHealthChecks();

            services.RegisterConsulServices(Program.AppName, Configuration);

            if(environment.IsDevelopment()){
                services.AddCors(options =>
                {
                    options.AddPolicy("development_cors",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                    });
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("development_cors");
            }

            app.UsePathBase("/iam");

            app.UseSwagger(c => {
                c.RouteTemplate = "oas/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = "/iam", Description="Identity Accesss Managerment" } };
                });
            });

            app.UseRouting();

            app.UseAuthorization();

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
