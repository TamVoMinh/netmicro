using Serilog;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nmro.Common.Services;

namespace Nmro.IAM.API
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("iams", new OpenApiInfo { Title = "Nmro.IAM.API.IAMS", Version = "v1" });
                c.SwaggerDoc("oidc", new OpenApiInfo { Title = "Nmro.IAM.API.OIDC", Version = "v1" });

                c.EnableAnnotations(true);
                c.CustomSchemaIds(x => x.Name);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
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
                });
            });

        public static IServiceCollection AddConfiguredLogging(this IServiceCollection services) =>
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog(dispose: true);
            });

        public static IServiceCollection AddCommonServices(this IServiceCollection services) =>
            services
                .AddTransient<IDateTime, MachineDateTime>()
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddHttpContextAccessor();

    }
}
