
namespace Nmro.IAM.Domain.Entities
{
    public class ApiResourceProperty : Property
    {
        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}
