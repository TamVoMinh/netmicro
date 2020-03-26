using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Extensions;
using Nmro.IAM.Domain.Entities;
using Nmro.IAM.Services;
using Npgsql;
using Polly;
using Polly.Retry;

public class IAMDbcontextSeeds
{
    private readonly IPasswordValidator _passwordValidator;

    public IAMDbcontextSeeds(IPasswordValidator passwordValidator)
    {
        _passwordValidator = passwordValidator;
    }

    public async Task SeedAsync(IAMDbcontext context, ILogger<IAMDbcontextSeeds> logger)
    {
        var policy = CreatePolicy(logger, nameof(IAMDbcontextSeeds));

        logger.LogInformation("Start seeding...");

        await policy.ExecuteAsync(async () =>
        {
            if (!context.IdentityUsers.Any())
            {
                await context.IdentityUsers.AddRangeAsync(SeedUsers());
                await context.SaveChangesAsync();
            }

            if (!context.Clients.Any())
            {
                await context.Clients.AddRangeAsync(SeedClients());
                await context.SaveChangesAsync();
            }

            if (!context.IdentityResources.Any())
            {
                await context.IdentityResources.AddRangeAsync(SeedIdentityResources());
                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                await context.ApiResources.AddRangeAsync(SeedApiResources());
                await context.SaveChangesAsync();
            }
        });

        logger.LogInformation("End seeding.");
    }

    private List<IdentityUser> SeedUsers()
    {
        var salt = _passwordValidator.GenerateSalt();
        return new List<IdentityUser>{
            new IdentityUser {
                UserName = "admin",
                Salt = salt,
                Password = _passwordValidator.HashWithPbkdf2(_passwordValidator.HashWithSha256("admin123"), salt),
                Email = "admin@nmro.local",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false
            }
        };
    }

    private List<Client> SeedClients()
    {
        return new List<Nmro.IAM.Domain.Entities.Client> {
            new Nmro.IAM.Domain.Entities.Client {
                Id = 2,
                ClientId = "nmro-website",
                ClientName = "Nmro MVC client - Hybrid Grant",
                ClientSecrets = new List<Secret>
                {
                   new Secret { Value = "nmro-website-Secret".Sha256(), Type = "SharedSecret" }
                },
                AllowedGrantTypes = new string[] { GrantType.Hybrid},
                AllowAccessTokensViaBrowser = false,
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 30,
                AllowedScopes = new List<string>
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {"http://nmro.local/signin-oidc"},
                PostLogoutRedirectUris = new List<string> {"http://nmro.local/signout-callback-oidc"},
                AllowedCorsOrigins = new List<string> {
                    "http://nmro.local",
                    "https://nmro.local"
                }
            },
            new Nmro.IAM.Domain.Entities.Client {
                Id = 3,
                ClientId = "nmro-website-localhost",
                ClientName = "Nmro Default Website - Hybrid Grant",
                ClientSecrets = new List<Secret>
                {
                   new Secret { Value = "nmro-website-Secret-localhost".Sha256(), Type = "SharedSecret" }
                },
                AllowedGrantTypes = new string[] { GrantType.Hybrid},
                AllowAccessTokensViaBrowser = false,
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 30,
                AllowedScopes = new List<string>
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {"http://localhost:8080/signin-oidc"},
                PostLogoutRedirectUris = new List<string> {"http://localhost:8080/signout-callback-oidc"},
                 AllowedCorsOrigins = new List<string> {
                    "http://localhost:8080",
                    "http://localhost:8081"
                }
            },
            new Nmro.IAM.Domain.Entities.Client {
                Id = 4,
                ClientId = "nmro-reactjs-client",
                ClientName = "Nmro ReactJS client",
                AllowedGrantTypes = new string[] { GrantType.Implicit},
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 30,
                AllowedScopes = new List<string>
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {"http://engage.nmro.local/signin-callback.html"},
                PostLogoutRedirectUris = new List<string> {"http://engage.nmro.local"},
                AllowedCorsOrigins = new List<string> {
                    "http://engage.nmro.local",
                    "https://engage.nmro.local"
                }
            },
            new Nmro.IAM.Domain.Entities.Client {
                Id = 5,
                ClientId = "nmro-angular-client-localhost",
                ClientName = "Nmro Angular client - localhost",
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 30,
                RequireClientSecret = false,
                AllowedGrantTypes = new string[] { GrantType.AuthorizationCode},
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                AllowedScopes = new List<string>
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
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
            new Nmro.IAM.Domain.Entities.Client {
                Id = 6,
                ClientId = "nmro-angular-client",
                ClientName = "Nmro Angular client",
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 30,
                RequireClientSecret = false,
                AllowedGrantTypes = new string[] { GrantType.AuthorizationCode}, // GrantTypes.Code
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                AllowedScopes = new List<string>
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
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
                AllowedCorsOrigins = new List<string> {
                    "http://control-centre.nmro.local",
                    "https://control-centre.nmro.local"
                }
            }
        };
    }

    private List<IdentityResource> SeedIdentityResources()
    {
        return new List<Nmro.IAM.Domain.Entities.IdentityResource>
        {
            new Nmro.IAM.Domain.Entities.IdentityResource
            {
                Name = StandardScopes.OpenId,
                DisplayName = "Your user identifier",
                Required = true,
                UserClaims = new List<string> {JwtClaimTypes.Subject },
                Enabled = true
            },
            new Nmro.IAM.Domain.Entities.IdentityResource
            {
                Name = StandardScopes.Profile,
                DisplayName = "User profile",
                Description = "Your user profile information (first name, last name, etc.)",
                Emphasize = true,
                UserClaims = new List<string> {
                    JwtClaimTypes.Name,
                    JwtClaimTypes.FamilyName,
                    JwtClaimTypes.GivenName,
                    JwtClaimTypes.MiddleName,
                    JwtClaimTypes.NickName,
                    JwtClaimTypes.PreferredUserName,
                    JwtClaimTypes.Profile,
                    JwtClaimTypes.Picture,
                    JwtClaimTypes.WebSite,
                    JwtClaimTypes.Gender,
                    JwtClaimTypes.BirthDate,
                    JwtClaimTypes.ZoneInfo,
                    JwtClaimTypes.Locale,
                    JwtClaimTypes.UpdatedAt
                },
                Enabled = true
            },
            new Nmro.IAM.Domain.Entities.IdentityResource // new IdentityResources.Email(),
            {
                Name = StandardScopes.Email,
                DisplayName = "Your email address",
                Emphasize = true,
                UserClaims = new List<string> { // (Constants.ScopeToClaimsMapping[IdentityServerConstants.StandardScopes.Email].ToList())
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified
                },
                Enabled = true
            },
            new Nmro.IAM.Domain.Entities.IdentityResource {
                Name = "role",
                UserClaims = new List<string> {"role"},
                Enabled = true
            }
        };
    }

    private List<ApiResource> SeedApiResources()
    {
        return new List<Nmro.IAM.Domain.Entities.ApiResource> {
            new Nmro.IAM.Domain.Entities.ApiResource {
                Id = 1,
                Name = "member",
                DisplayName = "member API",
                Description = "member API Access",
                UserClaims = new List<string> {"role"},
                Enabled = true,
                ApiSecrets = new List<Secret> { new Secret { Value = "scopeSecret".Sha256() } },
                Scopes = new List<Nmro.IAM.Domain.Entities.Scope> {
                    new Nmro.IAM.Domain.Entities.Scope { Name = "member" },
                    new Nmro.IAM.Domain.Entities.Scope { Name ="member.read" },
                    new Nmro.IAM.Domain.Entities.Scope { Name ="member.write" }
                }
            }
        };
    }

    private AsyncRetryPolicy CreatePolicy(ILogger<IAMDbcontextSeeds> logger, string prefix, int retries = 3)
    {
        return Policy.Handle<NpgsqlException>().
            WaitAndRetryAsync(
                retryCount: retries,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                }
            );
    }
}
