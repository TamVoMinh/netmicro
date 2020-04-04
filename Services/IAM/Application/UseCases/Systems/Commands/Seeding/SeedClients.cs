using System.Collections.Generic;
using Nmro.Common.Extentions;
using Nmro.IAM.Domain;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Application.UseCases.Systems
{
    public static class SeedClients
    {
        public static List<Client> List()
        {
            return new List<Client> {
                new Client {
                    Id = 2,
                    ClientId = "nmro-website",
                    ClientName = "Nmro MVC client - Hybrid Grant",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret { Value = "nmro-website-Secret".Sha256(), Type = OidcConstants.SecretTypes.SharedSecret }
                    },
                    AllowedGrantTypes = new List<ClientGrantType> { new ClientGrantType{ GrantType = GrantType.Hybrid} },
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime = 30,
                    AllowedScopes = new List<ClientScope>
                    {
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.OpenId},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Profile},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Email},
                        new ClientScope{ Scope =  "member"}
                    },
                    RedirectUris = new List<ClientRedirectUri>
                    {
                        new ClientRedirectUri{ RedirectUri="http://nmro.local/signin-oidc" }
                    },
                    PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>
                    {
                         new ClientPostLogoutRedirectUri{ PostLogoutRedirectUri="http://nmro.local/signout-callback-oidc"}
                    },
                    AllowedCorsOrigins = new List<ClientCorsOrigin> {
                        new ClientCorsOrigin{Origin="http://nmro.local"},
                        new ClientCorsOrigin{Origin="https://nmro.local"}
                    }
                },
                new Client {
                    Id = 3,
                    ClientId = "nmro-website-localhost",
                    ClientName = "Nmro Default Website - Hybrid Grant",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret { Value = "nmro-website-Secret-localhost".Sha256(), Type = OidcConstants.SecretTypes.SharedSecret }
                    },
                    AllowedGrantTypes = new List<ClientGrantType> { new ClientGrantType{ GrantType = GrantType.Hybrid} },
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime = 30,
                    AllowedScopes = new List<ClientScope>
                    {
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.OpenId},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Profile},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Email},
                        new ClientScope{ Scope =  "member"}
                    },
                    RedirectUris = new List<ClientRedirectUri>
                    {
                        new ClientRedirectUri{ RedirectUri = "http://localhost:8080/signin-oidc" }
                    },
                    PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>
                    {
                         new ClientPostLogoutRedirectUri{ PostLogoutRedirectUri="http://localhost:8080/signout-callback-oidc"}
                    },
                    AllowedCorsOrigins = new List<ClientCorsOrigin> {
                        new ClientCorsOrigin{Origin="http://localhost:8080"}
                    }
                },
                new Client {
                    Id = 4,
                    ClientId = "nmro-reactjs-client",
                    ClientName = "Nmro ReactJS client",
                    AllowedGrantTypes = new List<ClientGrantType> { new ClientGrantType{ GrantType = GrantType.Implicit} },
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime = 30,
                    AllowedScopes = new List<ClientScope>
                    {
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.OpenId},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Profile},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Email},
                        new ClientScope{ Scope =  "member"}
                    },
                    RedirectUris = new List<ClientRedirectUri>
                    {
                        new ClientRedirectUri{ RedirectUri="http://engage.nmro.local/signin-callback.html" }
                    },
                    PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>
                    {
                         new ClientPostLogoutRedirectUri{ PostLogoutRedirectUri="http://engage.nmro.local"}
                    },
                    AllowedCorsOrigins = new List<ClientCorsOrigin> {
                        new ClientCorsOrigin{Origin="http://engage.nmro.local"}
                    }
                },
                new Client {
                    Id = 5,
                    ClientId = "nmro-angular-client-localhost",
                    ClientName = "Nmro Angular client - localhost",
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime = 30,
                    RequireClientSecret = false,
                    AllowedGrantTypes = new List<ClientGrantType> { new ClientGrantType{ GrantType = GrantType.AuthorizationCode} },
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new List<ClientScope>
                    {
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.OpenId},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Profile},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Email},
                        new ClientScope{ Scope =  "apigateway"},
                        new ClientScope{ Scope =  "member"}

                    },
                    RedirectUris = new List<ClientRedirectUri>
                    {
                        new ClientRedirectUri{ RedirectUri = "http://localhost:4200" },
                        new ClientRedirectUri{ RedirectUri = "http://localhost:4200/silent-renew.html" }
                    },
                    PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>
                    {
                        new ClientPostLogoutRedirectUri{ PostLogoutRedirectUri="http://localhost:4200"},
                        new ClientPostLogoutRedirectUri{ PostLogoutRedirectUri="http://localhost:4200/web/unauthorized"}
                    },
                    AllowedCorsOrigins = new List<ClientCorsOrigin> {
                        new ClientCorsOrigin{Origin="http://localhost:4200"}
                    }
                },
                new Client {
                    Id = 6,
                    ClientId = "nmro-angular-client",
                    ClientName = "Nmro Angular client",
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime = 30,
                    RequireClientSecret = false,
                    AllowedGrantTypes = new List<ClientGrantType>
                    {
                        new ClientGrantType{ GrantType = GrantType.AuthorizationCode}
                    },
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new List<ClientScope>
                    {
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.OpenId},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Profile},
                        new ClientScope{ Scope =  OidcConstants.StandardScopes.Email},
                        new ClientScope{ Scope =  "apigateway"},
                        new ClientScope{ Scope =  "member"}
                    },
                    RedirectUris = new List<ClientRedirectUri>
                    {
                        new ClientRedirectUri{ RedirectUri = "http://control-centre.nmro.local" },
                        new ClientRedirectUri{ RedirectUri = "http://control-centre.nmro.local/silent-renew.html" }
                    },
                    PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>
                    {
                        new ClientPostLogoutRedirectUri{ PostLogoutRedirectUri="http://control-centre.nmro.local"},
                        new ClientPostLogoutRedirectUri{ PostLogoutRedirectUri="http://control-centre.nmro.local/web/unauthorized"}
                    },
                    AllowedCorsOrigins = new List<ClientCorsOrigin> {
                        new ClientCorsOrigin{Origin="http://control-centre.nmro.local"}
                    }
                }
            };
        }

    }
}
