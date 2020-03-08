using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Nmro.Oidc.Storage
{
    internal class Clients
    {
        public static IEnumerable<Client> Get() => new List<Client> {
            new Client {
                ClientId = "oauthClient",
                ClientName = "Example Client Credentials Client Application",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("superSecretPassword".Sha256())},
                AllowedScopes = new List<string> {"customAPI.read"}
            },
            new Client {
                ClientId = "nmro-website",
                ClientName = "Nmro MVC client - Hybrid Grant",
                ClientSecrets = new List<Secret>{new Secret("nmro-website-Secret".Sha256())}  ,
                AllowedGrantTypes = GrantTypes.Hybrid,
                AllowAccessTokensViaBrowser = false,
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {"http://nmro.local/signin-oidc"},
                PostLogoutRedirectUris = new List<string> {"http://nmro.local/signout-callback-oidc"}
            },
            new Client {
                ClientId = "nmro-reactjs-client",
                ClientName = "Nmro ReactJS client",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {"http://engage.nmro.local/signin-callback.html"},
                PostLogoutRedirectUris = new List<string> {"http://engage.nmro.local"},
                AllowedCorsOrigins = new List<string> { "http://engage.nmro.local" }
            },
            new Client {
                ClientId = "nmro-angular-client-localhost",
                ClientName = "Nmro Angular client - localhost",
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 30,
                RequireClientSecret = false,
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {
                    "http://localhost:4200",
                    "http://localhost:4200/silent-renew.html"
                },
                PostLogoutRedirectUris = new List<string> {
                    "http://localhost:4200",
                    "http://localhost:4200/web/unauthorized"
                },
                AllowedCorsOrigins = new List<string> {
                    "http://localhost:4200"
                }
            },
             new Client {
                ClientId = "nmro-angular-client",
                ClientName = "Nmro Angular client",
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 30,
                RequireClientSecret = false,
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string>
                {
                    "http://control-centre.nmro.local",
                    "http://control-centre.nmro.local/silent-renew.html"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "http://control-centre.nmro.local",
                    "http://control-centre.nmro.local/web/unauthorized"
                },
                AllowedCorsOrigins = new List<string> { "http://control-centre.nmro.local" }
            },
            new Client {
                ClientId = "nmro-ionic-client",
                ClientName = "Nmro Ionic client",
                AllowedGrantTypes = GrantTypes.DeviceFlow,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {"http://192.168.1.7:8100/signin-callback.html"},
                PostLogoutRedirectUris = new List<string> {"http://192.168.1.7:8100"},
                AllowedCorsOrigins = new List<string> { "http://engage.nmro.local" }
            },
        };
    }
}
