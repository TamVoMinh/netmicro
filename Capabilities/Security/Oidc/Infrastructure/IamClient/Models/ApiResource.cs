using System.Collections.Generic;

namespace Nmro.Oidc.Infrastructure.IamClient.Models
{
    public class ApiResource : Resource
    {

        public ICollection<Secret> ApiSecrets { get; set; } = new HashSet<Secret>();

        public ICollection<string> Scopes { get; set; } = new HashSet<string>();

        public ICollection<string> AllowedAccessTokenSigningAlgorithms { get; set; } = new HashSet<string>();
    }
}
