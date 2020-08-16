using System.Collections.Generic;
using Nmro.IAM.Domain;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Core.UseCases.Systems
{
    public static class SeedIdentityResources
    {
        public static List<IdentityResource> List()
        {
            return new List<Nmro.IAM.Domain.Entities.IdentityResource>
            {
                new Nmro.IAM.Domain.Entities.IdentityResource
                {
                    Name = OidcConstants.StandardScopes.OpenId,
                    DisplayName = "Your user identifier",
                    Required = true,
                    UserClaims = new List<IdentityResourceClaim> {
                        new IdentityResourceClaim { Type = JwtClaimTypes.Subject}
                    },
                    Enabled = true
                },
                new Nmro.IAM.Domain.Entities.IdentityResource
                {
                    Name = OidcConstants.StandardScopes.Profile,
                    DisplayName = "User profile",
                    Description = "Your user profile information (first name, last name, etc.)",
                    Emphasize = true,
                    UserClaims = new List<IdentityResourceClaim> {
                        new IdentityResourceClaim { Type = JwtClaimTypes.Name},
                        new IdentityResourceClaim { Type = JwtClaimTypes.FamilyName},
                        new IdentityResourceClaim { Type = JwtClaimTypes.GivenName},
                        new IdentityResourceClaim { Type = JwtClaimTypes.MiddleName},
                        new IdentityResourceClaim { Type = JwtClaimTypes.NickName},
                        new IdentityResourceClaim { Type = JwtClaimTypes.PreferredUserName},
                        new IdentityResourceClaim { Type = JwtClaimTypes.Profile},
                        new IdentityResourceClaim { Type = JwtClaimTypes.Picture},
                        new IdentityResourceClaim { Type = JwtClaimTypes.Gender},
                        new IdentityResourceClaim { Type = JwtClaimTypes.BirthDate},
                        new IdentityResourceClaim { Type = JwtClaimTypes.ZoneInfo},
                        new IdentityResourceClaim { Type = JwtClaimTypes.Locale},
                        new IdentityResourceClaim { Type = JwtClaimTypes.UpdatedAt}
                    },
                    Enabled = true
                },
                new Nmro.IAM.Domain.Entities.IdentityResource
                {
                    Name = OidcConstants.StandardScopes.Email,
                    DisplayName = "Your email address",
                    Emphasize = true,
                    UserClaims = new List<IdentityResourceClaim> {
                        new IdentityResourceClaim { Type = JwtClaimTypes.Email},
                        new IdentityResourceClaim { Type = JwtClaimTypes.EmailVerified}
                    },
                    Enabled = true
                },
                new Nmro.IAM.Domain.Entities.IdentityResource {
                    Name = "role",
                    UserClaims = new List<IdentityResourceClaim> {
                        new IdentityResourceClaim { Type = "role"},
                    },
                    Enabled = true
                }
            };
        }
    }
}
