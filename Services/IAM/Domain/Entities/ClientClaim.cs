
namespace Nmro.IAM.Domain.Entities
{
    public class ClientClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
