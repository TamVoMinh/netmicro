using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Queries
{
    public class ValidateCredentialQuery: IRequest<IdentityUser>
    {
        public string Username {get;set;}
        public string Password {get;set;}
    }
}
