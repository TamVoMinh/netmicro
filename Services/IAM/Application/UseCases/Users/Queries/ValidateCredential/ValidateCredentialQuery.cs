using MediatR;
using Nmro.IAM.Application.Users.Models;

namespace Nmro.IAM.Application.Users.Queries
{
    public class ValidateCredentialQuery: IRequest<IdentityUserModel>
    {
        public CredentialModel Credential {get; set;}
    }
}
