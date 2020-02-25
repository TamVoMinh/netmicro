using Nmro.IAM.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Models
{
    public class ApiResourceModel : ResourceBaseModel
    {
        public ICollection<Secret> ApiSecrets { get; set; }
        
        public ICollection<Scope> Scopes { get; set; }
    }
}
