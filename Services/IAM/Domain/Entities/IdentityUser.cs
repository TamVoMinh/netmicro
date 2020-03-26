using System;

namespace Nmro.IAM.Domain.Entities
{
    public class IdentityUser : EntityBase<long>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public byte[] Salt { get; set; }

        public DateTime LastSuccessfulLogin { get; set; }

        public DateTime LastFailedLogin { get; set; }

        public bool IsDeleted { get; set; }
    }

}
