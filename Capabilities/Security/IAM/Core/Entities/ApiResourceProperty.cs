
namespace Nmro.Security.IAM.Core.Entities
{
    public class ApiResourceProperty : Property
    {
        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}
