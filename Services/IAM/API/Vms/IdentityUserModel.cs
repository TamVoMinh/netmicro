using System;

namespace Nmro.IAM.API.Vms
{
    public class IdentityUserModel{
        public int Id { get; set; }
        public string UserName {get;set;}
        public string Email {get;set;}

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class CredentialModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
