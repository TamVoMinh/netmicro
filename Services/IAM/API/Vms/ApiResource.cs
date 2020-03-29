using System.Collections.Generic;

namespace Nmro.IAM.API.Vms
{

    public class ApiResource : Resource
    {
        public ICollection<Secret> ApiSecrets { get; set; }

        public ICollection<Scope> Scopes { get; set; }
    }
}
