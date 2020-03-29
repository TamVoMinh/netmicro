using System.Collections.Generic;

namespace Nmro.IAM.API.Vms
{
    public class Scope
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public bool Emphasize { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }

        public ICollection<string> UserClaims { get; set; }
    }
}
