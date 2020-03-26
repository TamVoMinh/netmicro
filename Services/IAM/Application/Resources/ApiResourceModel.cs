using System.Collections.Generic;

namespace Nmro.IAM.Application.Resources
{
    public class ApiResourceModel : ResourceBaseModel
    {
        public ICollection<SecretModel> ApiSecrets { get; set; }

        public ICollection<ScopeModel> Scopes { get; set; }
    }
}
