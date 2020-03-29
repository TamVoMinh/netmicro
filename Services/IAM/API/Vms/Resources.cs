using System;
using System.Linq;
using System.Collections.Generic;

namespace Nmro.IAM.API.Vms
{
    public class Resources
    {
        public Resources(){}
        public Resources(Application.UseCases.Resources.Models.AllResources all)
        {
            if(all==null) throw new ArgumentNullException("all: Application.UseCases.Resources.Models.AllResources");

            IdentityResources = all.IdentityResources.Select(x => x.ToViewModel()).ToArray();
            ApiResources = all.ApiResources.Select(x => x.ToViewModel()).ToArray();
            OfflineAccess = all.OfflineAccess;
        }
        public bool OfflineAccess { get; set; }

        public ICollection<IdentityResource> IdentityResources { get; set; }

        public ICollection<ApiResource> ApiResources { get; set; }
    }
}

