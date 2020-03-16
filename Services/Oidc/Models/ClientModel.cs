using System.Collections.Generic;

namespace Nmro.Oidc.Models
{
    public class ClientModel
    {
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public ICollection<string> AllowedScopes { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public bool RequireConsent { get; set; }
        public ICollection<string> AllowedGrantTypes { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public ICollection<string> RedirectUris { get; set; }
        public ICollection<string> PostLogoutRedirectUris { get; set; }

        public ICollection<SecretModel> ClientSecrets { get; set; }
    }
}
