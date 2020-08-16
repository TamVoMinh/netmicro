using MediatR;
using Nmro.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.IAM.Core.UseCases.Users.Queries
{
    public class ValidateCredentialQuery: IRequest<IdentityUser>
    {
        public string Username {get;set;}
        public string Password {get;set;}
    }
}
