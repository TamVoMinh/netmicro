using System.Collections.Generic;
using IdentityServer4.Models;
namespace Nmro.Oidc.Storage
{
    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };

        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource> {
            new ApiResource {
                Name = "member",
                DisplayName = "member API",
                Description = "member API Access",
                UserClaims = new List<string> {"role"},
                ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                Scopes = new List<Scope> {
                    new Scope("member"),
                    new Scope("member.read"),
                    new Scope("member.write")
                }
            }
        };
    }
}