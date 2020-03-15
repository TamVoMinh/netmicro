using System;

namespace Nmro.Oidc.Models
{
    public class SecretModel
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }

        public int ClientId { get; set; }

        public int ApiResourceId { get; set; }

        public ClientModel Client { get; set; }
    }
}
