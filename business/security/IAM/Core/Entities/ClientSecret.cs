
namespace Nmro.Security.IAM.Core.Entities
{
    public class ClientSecret : Secret
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
