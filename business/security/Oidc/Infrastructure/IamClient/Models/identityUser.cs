using Nmro.Shared.Models;
namespace Nmro.Oidc.Infrastructure.IamClient.Models
{
    public class IdentityUser : AuditableModel
    {
        public int Id { get; set; }
        public string Username {get;set;}
        public string Email {get;set;}
    }
}
