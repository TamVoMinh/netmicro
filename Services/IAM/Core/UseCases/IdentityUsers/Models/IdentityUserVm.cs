using System.Collections.Generic;
using Nmro.Common.Models;

namespace Nmro.IAM.Core.UseCases.Users.Dtos
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
    }

    public class PageIdentityUserModel: PageResult<IdentityUser>{
        public PageIdentityUserModel(int total, int offset, int limit, IEnumerable<IdentityUser> items): base(total, offset, limit, items){}
    }
}
