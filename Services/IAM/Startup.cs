using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Nmro.Web.ServiceDiscovery;
using Nmro.IAM.Services;

namespace Nmro.IAM
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
            services.AddAutoMapper(typeof(Startup));

            services.AddLogging(logging => {
                logging.ClearProviders();
                logging.AddSerilog(dispose: true);
            });

            services.AddIAMDbcontext(
                Configuration.GetConnectionString("DefaultConnection"),
                typeof(Startup).GetTypeInfo().Assembly.GetName().Name
            );

            services.AddControllers()
                    .AddJsonOptions(options=>
                    {
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    });

            services.AddScoped<IPasswordValidator, PasswordValidator>();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations(true);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nmro.IAM", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                    Name = "AuthN",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
               c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    }
                );
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
