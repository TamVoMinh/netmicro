
namespace Nmro.Security.IAM.Core.Entities
{
    public class ClientPostLogoutRedirectUri
    {
        public int Id { get; set; }
        public string PostLogoutRedirectUri { get; set; }        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
