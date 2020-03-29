using System.Collections.Generic;

namespace Nmro.IAM.API.Vms
{
    public abstract class Resource
    {
        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public ICollection<string> UserClaims { get; set; }

        public IDictionary<string, string> Properties { get; set; }
    }
}
