using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nmro.Hosting.OidcClients
{
    public static class AuthenticationExtentions
    {
        public static IServiceCollection AddOidcHybridAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            OidcOptions oidcOptions = configuration.GetSection("Oidc").Get<OidcOptions>();
            if(oidcOptions==null){
                throw new ArgumentNullException(typeof(OidcOptions).Name);
            }

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(
                setup => {
                    setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime);
                    setup.Cookie.SameSite =  Microsoft.AspNetCore.Http.SameSiteMode.Unspecified;
                }
            )
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
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
