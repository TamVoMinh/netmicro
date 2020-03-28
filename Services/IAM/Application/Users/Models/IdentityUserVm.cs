using System;

namespace Nmro.IAM.Application.Users.Models
{
    public class CredentialModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class VerifierModel
    {
        public string Email {get; set;}

        public string PhoneNumber {get; set;}
    }

    public class CreatingUserModel: CredentialModel
    {
        public VerifierModel Verifier {get; set;}
    }

    public class UpdatingUserModel: VerifierModel
    {
        public long Id { get; set;}
        public string Password {get; set;}
        public DateTime Updated { get; set; }
    }
}
