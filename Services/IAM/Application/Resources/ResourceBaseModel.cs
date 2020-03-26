using System.Collections.Generic;

namespace Nmro.IAM.Application.Resources
{
    public class ResourceBaseModel: BaseEntityModel<int>
    {
        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public ICollection<string> UserClaims { get; set; }
    }
}
