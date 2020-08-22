using System;
using Nmro.Security.IAM.Core;

namespace Nmro.Security.IAM.Core.Entities
{
    public class IdentityUser : AuditableEntity
    {
        public int Id {get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public DateTime LastSuccessfulLogin { get; set; }
        public DateTime LastFailedLogin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
