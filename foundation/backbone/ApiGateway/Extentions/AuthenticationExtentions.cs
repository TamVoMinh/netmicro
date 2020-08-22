using System;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Nmro.Foundation.Backbone.ApiGateway.Extentions
{
    public static class AuthenticationExtentions
    {
        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services, Action<Oauth2Options> configOption)
            => services.AddOidcAuthentication(configOption.build());


        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services, Oauth2Options config)
        {
            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(config.SchemeName, o =>{
                    o.Authority = config.Authority;
                    o.ApiName = config.ApiName;
                    o.ApiSecret = config.ApiSecret;
                    o.RequireHttpsMetadata = config.RequireHttps;
                });

            return services;
        }

        private static Oauth2Options build(this Action<Oauth2Options> configOption)
        {
            var options = new Oauth2Options();
            configOption(options);
            return options;
        }
    }
}
