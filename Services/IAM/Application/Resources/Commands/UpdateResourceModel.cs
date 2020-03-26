using System.Collections.Generic;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class UpdateResourceModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool? Enabled { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public ICollection<string> UserClaims { get; set; }

        public ICollection<string> Scopes { get; set; }

    }
}
