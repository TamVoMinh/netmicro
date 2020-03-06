using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Models
{
    public class ResourcesModel
    {
        public ICollection<ApiResourceModel> ApiResources { get; set; }
        public ICollection<IdentityResourceModel> IdentityResources { get; set; }
    }
}
