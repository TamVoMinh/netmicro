using System.Collections.Generic;
using Nmro.IAM.Domain.Entities;
using Nmro.Common.Extentions;

namespace Nmro.IAM.Application.UseCases.Systems
{
    public static class SeedApiResources
    {
        public static List<ApiResource> List()
        {
            return new List<ApiResource> {
                new ApiResource {
                    Id = 1,
                    Name = "member",
                    DisplayName = "member API",
                    Description = "member API Access",
                    UserClaims = new List<ApiResourceClaim> { new ApiResourceClaim{ Type = "role"} },
                    Enabled = true,
                    Secrets = new List<ApiResourceSecret> { new ApiResourceSecret { Value = "scopeSecret".Sha256() } },
                    Scopes = new List<ApiResourceScope> {
                        new ApiResourceScope { Scope ="member" },
                        new ApiResourceScope { Scope ="member.read" },
                        new ApiResourceScope { Scope ="member.write" }
                    }
                }
            };
        }
    }
}
