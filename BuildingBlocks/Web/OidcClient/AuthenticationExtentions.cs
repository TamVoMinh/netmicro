using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nmro.Web.OidcClients
{
    public static class AuthenticationExtentions
    {
        public static IServiceCollection AddOidcHybridAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            OidcOptions oidcOptions = configuration.GetSection("Oidc").Get<OidcOptions>();
            if(oidcOptions==null){
                throw new ArgumentNullException(typeof(OidcOptions).Name);
            }

            var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
            .AddOpenIdConnect(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = oidcOptions.Authority;
                options.SignedOutRedirectUri = oidcOptions.SignedOutRedirectUri;
                options.ClientId = oidcOptions.ClientId;
                options.ClientSecret = oidcOptions.ClientSecret;
                options.ResponseType =  "code id_token";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.RequireHttpsMetadata = false;
                Array.ForEach(oidcOptions.Scopes, scope => options.Scope.Add(scope));
            });

            return services;
        }
    }
}
