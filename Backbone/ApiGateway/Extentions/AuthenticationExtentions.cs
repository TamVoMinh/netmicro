using IdentityServer4.AccessTokenValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Nmro.ApiGateway.Extentions
{
    public static class AuthenticationExtentions{
        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer("Authorization", o =>{
                    o.Authority = configuration.GetValue<string>("IdentityUrl");
                    o.Audience = "apigateway";
                    o.RequireHttpsMetadata = false;
                });

            return services;
        }
    }
}
