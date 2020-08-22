using MediatR;
using Nmro.Security.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.Users.Queries
{
    public class ValidateCredentialQuery: IRequest<IdentityUser>
    {
        public string Username {get;set;}
        public string Password {get;set;}
    }
}
