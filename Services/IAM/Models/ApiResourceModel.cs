using System.Collections.Generic;

namespace Nmro.IAM.Models
{
    public class ApiResourceModel : ResourceBaseModel
    {
        public ICollection<SecretModel> ApiSecrets { get; set; }
        
        public ICollection<ScopeModel> Scopes { get; set; }
    }
}
