using Nmro.Common.Models;

namespace Nmro.IAM.Core.UseCases.Users.Models
{
    public class IdentityUser : AuditableModel
    {
        public int Id { get; set; }
        public string Username {get;set;}
        public string Email {get;set;}
    }
 }
