using Nmro.Common.Models;

namespace Nmro.IAM.Application.UseCases.Users.Models
{
    public class IdentityUser : AuditableModel
    {
        public int Id { get; set; }
        public string UserName {get;set;}
        public string Email {get;set;}
    }
 }
