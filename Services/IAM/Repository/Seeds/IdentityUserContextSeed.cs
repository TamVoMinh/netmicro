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
        });

        logger.LogInformation("End seeding.");
    }

    private List<IdentityUser> SeedUsers()
    {
        return new List<IdentityUser>{
            new IdentityUser { UserName = "admin", Password = "admin123", Email = "admin@nmro.local" }
        };
    }

    private List<Client> SeedClients()
    {
        return new List<Client> {
            new Client {
                ClientId = "oauthClient",
                ClientName = "Example Client Credentials Client Application",
                AllowedGrantTypes = new[] { GrantType.ClientCredentials}, // GrantTypes.ClientCredentials
                ClientSecrets = new List<Secret>
                {
                    new Secret { Value = "superSecretPassword".Sha256() }
                },
                AllowedScopes = new List<string> {"customAPI.read"}
            },
            new Client {
                ClientId = "nmro-website",
                ClientName = "Nmro MVC client - Hybrid Grant",
                ClientSecrets = new List<Secret>
                {
                    new Secret { Value = "nmro-website-Secret".Sha256() }
                },
                AllowedGrantTypes = new[] { GrantType.Hybrid}, // GrantTypes.Hybrid
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

    private List<IdentityResource> SeedIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResource // new IdentityResources.OpenId(),
            {
                Name = StandardScopes.OpenId,
                DisplayName = "Your user identifier",
                Required = true,
                UserClaims = new List<string> {JwtClaimTypes.Subject },
            },
            new IdentityResource // new IdentityResources.Profile(),
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
            new IdentityResource // new IdentityResources.Email(),
            {
                Name = StandardScopes.Email,
                DisplayName = "Your email address",
                Emphasize = true,
                UserClaims = new List<string> { // (Constants.ScopeToClaimsMapping[IdentityServerConstants.StandardScopes.Email].ToList())
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified
                }
            },
            new IdentityResource {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };
    }

    private List<ApiResource> SeedApiResources()
    {
        return new List<ApiResource> {
            new ApiResource {
                Name = "member",
                DisplayName = "member API",
                Description = "member API Access",
                UserClaims = new List<string> {"role"},
                ApiSecrets = new List<Secret> { new Secret { Value = "scopeSecret".Sha256() }},
                Scopes = new List<Scope> {
                    new Scope { Name = "member" },
                    new Scope { Name ="member.read" },
                    new Scope { Name ="member.write" }
                }
            }
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
