using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Models
{
    public class IdentityResourceModel : ResourceModel
    {
        public bool Required { get; set; }
        
        public bool Emphasize { get; set; }
        
        public bool ShowInDiscoveryDocument { get; set; }
    }
}
