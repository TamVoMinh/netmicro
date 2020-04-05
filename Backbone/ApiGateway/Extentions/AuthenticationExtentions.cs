using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nmro.Common.Extentions;

namespace Nmro.ApiGateway.Extentions
{
    public static class AuthenticationExtentions{
        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication("Authorization", o =>{
                    o.Authority = configuration.GetValue<string>("IdentityUrl");
                    o.ApiName = "apigateway";
                    o.ApiSecret = "ApigatewaySecret".Sha256();
                    o.RequireHttpsMetadata = false;
                });

            return services;
        }
    }
}
