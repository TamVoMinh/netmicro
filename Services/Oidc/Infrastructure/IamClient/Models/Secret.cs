using System;

namespace Nmro.Oidc.Infrastructure.IamClient.Models
{
    public class Secret
    {

        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
    }
}
