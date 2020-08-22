using Nmro.Shared.Models;

namespace Nmro.Security.IAM.Core.UseCases.Users.Dtos
{
    public class IdentityUser : AuditableModel
    {
        public int Id { get; set; }
        public string Username {get;set;}
        public string Email {get;set;}
    }
 }
