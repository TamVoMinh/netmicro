
namespace Nmro.Security.IAM.Core.Entities
{
    public class ClientProperty : Property
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
