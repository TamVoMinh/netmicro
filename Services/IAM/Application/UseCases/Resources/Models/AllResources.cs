using System.Collections.Generic;
using System.Linq;
namespace Nmro.IAM.Application.UseCases.Resources.Models
{
    public class AllResources
    {
        public AllResources(){}

        public AllResources(AllResources other)
            : this(other.IdentityResources, other.ApiResources, other.ApiScopes)
        {
            OfflineAccess = other.OfflineAccess;
        }

        public AllResources(IEnumerable<IdentityResource> identityResources, IEnumerable<ApiResource> apiResources, IEnumerable<ApiScope> apiScopes)
        {
            if (identityResources?.Any() == true)
            {
                IdentityResources = new HashSet<IdentityResource>(identityResources.ToArray());
            }
            if (apiResources?.Any() == true)
            {
                ApiResources = new HashSet<ApiResource>(apiResources.ToArray());
            }
            if (apiScopes?.Any() == true)
            {
                ApiScopes = new HashSet<ApiScope>(apiScopes.ToArray());
            }
        }

        public bool OfflineAccess { get; set; }

        public ICollection<IdentityResource> IdentityResources { get; set; } = new HashSet<IdentityResource>();

        public ICollection<ApiResource> ApiResources { get; set; } = new HashSet<ApiResource>();

        public ICollection<ApiScope> ApiScopes { get; set; } = new HashSet<ApiScope>();
    }
}
