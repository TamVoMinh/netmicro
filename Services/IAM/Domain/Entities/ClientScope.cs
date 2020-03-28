
namespace Nmro.IAM.Domain.Entities
{
    public class ClientScope
    {
        public int Id { get; set; }
        public string Scope { get; set; }        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
