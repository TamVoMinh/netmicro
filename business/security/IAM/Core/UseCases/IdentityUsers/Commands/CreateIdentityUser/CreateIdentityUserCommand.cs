using MediatR;
using Nmro.Security.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.Users.Commands
{
    public class CreateIdentityUserCommand: IRequest<int> {
       public CreatingUserModel Model {get; set;}
    }
}
