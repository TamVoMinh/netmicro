using System.Collections.Generic;
using Nmro.Common.Models;

namespace Nmro.IAM.Core.UseCases.Clients.Models
{
    public abstract class ClientModelBase {
         public IEnumerable<string> ClientSecrets { get; set; }
        public IEnumerable<string> AllowedGrantTypes { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; } = false;
        public bool RequireConsent { get; set; } = false;
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } = true;
        public int AccessTokenLifetime { get; set; } = 3600;
        public int IdentityTokenLifetime { get; set; } = 30;
        public IEnumerable<string> AllowedScopes { get; set; }
        public IEnumerable<string> RedirectUris { get; set; }
        public IEnumerable<string> PostLogoutRedirectUris { get; set; }
        public IEnumerable<string> AllowedCorsOrigins { get; set; }
    }
    public class CreateClientModel: ClientModelBase
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
    }

    public class UpdateClientModel : ClientModelBase
    {
        public int Id {get;set;}
    }

    public class PageClient: PageResult<Client>{
        public PageClient(int total, int offset, int limit, IEnumerable<Client> items): base(total, offset, limit, items){}
    }

}
