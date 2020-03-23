using System.Collections.Generic;

namespace Nmro.IAM.Models
{
    public class ResourcesModel
    {
        public ICollection<ApiResourceModel> ApiResources { get; set; }
        public ICollection<IdentityResourceModel> IdentityResources { get; set; }
    }
}
