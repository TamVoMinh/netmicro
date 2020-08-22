using System.Collections.Generic;
namespace Nmro.Oidc.Infrastructure.IamClient.Models
{
    public abstract class Resource
    {

        public bool Enabled { get; set; } = true;

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool ShowInDiscoveryDocument { get; set; } = true;

        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();

        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
