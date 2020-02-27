using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Extensions;
using Nmro.IAM.Repository;
using Nmro.IAM.Repository.Entities;
using Npgsql;
using Polly;
using Polly.Retry;

public class IdentityUserContextSeed
{
    public async Task SeedAsync(IAMDbcontext context, ILogger<IdentityUserContextSeed> logger)
    {
        var policy = CreatePolicy(logger, nameof(IdentityUserContextSeed));

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

            if (!context.Secrets.Any())
            {
                await context.Secrets.AddRangeAsync(SeedSecrets());
                await context.SaveChangesAsync();
            }
        });

        logger.LogInformation("End seeding.");
    }

    private List<IdentityUser> SeedUsers()
    {
        return new List<IdentityUser>{
            new IdentityUser { UserName = "admin", Password = "admin123", Email = "admin@nmro.local" }
        };
    }

    private List<Nmro.IAM.Repository.Entities.Client> SeedClients()
    {
        return new List<Nmro.IAM.Repository.Entities.Client> {
            new Nmro.IAM.Repository.Entities.Client {
                Id = 1,
                ClientId = "oauthClient",
                ClientName = "Example Client Credentials Client Application",
                AllowedGrantTypes =  new string[] { GrantType.ClientCredentials}, // GrantTypes.ClientCredentials
                //ClientSecrets = new List<Secret>
                //{
                    
                //    new Secret { Value = "superSecretPassword".Sha256() }
                //},
                AllowedScopes = new List<string> {"customAPI.read"}
            },
            new Nmro.IAM.Repository.Entities.Client {
                Id = 2,
                ClientId = "nmro-website",
                ClientName = "Nmro MVC client - Hybrid Grant",
                //ClientSecrets = new List<Secret>
                //{
                //    new Secret { Value = "nmro-website-Secret".Sha256() }
                //},
                AllowedGrantTypes = new string[] { GrantType.Hybrid}, // GrantTypes.Hybrid
                AllowAccessTokensViaBrowser = false,
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedScopes = new List<string>
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    "member"
                },
                RedirectUris = new List<string> {"http://nmro.local/signin-oidc"},
                PostLogoutRedirectUris = new List<string> {"http://nmro.local/signout-callback-oidc"}
            }
        };
    }

    private List<Nmro.IAM.Repository.Entities.IdentityResource> SeedIdentityResources()
    {
        return new List<Nmro.IAM.Repository.Entities.IdentityResource>
        {
            new Nmro.IAM.Repository.Entities.IdentityResource // new IdentityResources.OpenId(),
            {
                Name = StandardScopes.OpenId,
                DisplayName = "Your user identifier",
                Required = true,
                UserClaims = new List<string> {JwtClaimTypes.Subject },
            },
            new Nmro.IAM.Repository.Entities.IdentityResource // new IdentityResources.Profile(),
            {
                Name = StandardScopes.Profile,
                DisplayName = "User profile",
                Description = "Your user profile information (first name, last name, etc.)",
                Emphasize = true,
                UserClaims = new List<string> { // Constants.ScopeToClaimsMapping[IdentityServerConstants.StandardScopes.Profile].ToList()
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
                }
            },
            new Nmro.IAM.Repository.Entities.IdentityResource // new IdentityResources.Email(),
            {
                Name = StandardScopes.Email,
                DisplayName = "Your email address",
                Emphasize = true,
                UserClaims = new List<string> { // (Constants.ScopeToClaimsMapping[IdentityServerConstants.StandardScopes.Email].ToList())
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified
                }
            },
            new Nmro.IAM.Repository.Entities.IdentityResource {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };
    }

    private List<Nmro.IAM.Repository.Entities.ApiResource> SeedApiResources()
    {
        return new List<Nmro.IAM.Repository.Entities.ApiResource> {
            new Nmro.IAM.Repository.Entities.ApiResource {
                Id = 1,
                Name = "member",
                DisplayName = "member API",
                Description = "member API Access",
                UserClaims = new List<string> {"role"},
                //ApiSecrets = new List<Secret> { new Secret { Value = "scopeSecret".Sha256() }},
                Scopes = new List<Nmro.IAM.Repository.Entities.Scope> {
                    new Nmro.IAM.Repository.Entities.Scope { Name = "member" },
                    new Nmro.IAM.Repository.Entities.Scope { Name ="member.read" },
                    new Nmro.IAM.Repository.Entities.Scope { Name ="member.write" }
                }
            }
        };
    }

    private List<Nmro.IAM.Repository.Entities.Secret> SeedSecrets()
    {
        return new List<Nmro.IAM.Repository.Entities.Secret> {
            new Nmro.IAM.Repository.Entities.Secret { Value = "superSecretPassword".Sha256(), ClientId = 1 },
            new Nmro.IAM.Repository.Entities.Secret { Value = "nmro-website-Secret".Sha256(), ClientId = 2 },
            new Nmro.IAM.Repository.Entities.Secret { Value = "scopeSecret".Sha256(), ApiResourceId = 1 }
        };
    }

    private AsyncRetryPolicy CreatePolicy(ILogger<IdentityUserContextSeed> logger, string prefix, int retries = 3)
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
