using System.Collections.Generic;

namespace Nmro.IAM.Models
{
    public class ResourceBaseModel
    {
        public bool Enabled { get; set; }
        
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public ICollection<string> UserClaims { get; set; }
    }
}
