using MediatR;
using Nmro.IAM.Core.UseCases.Users.Models;

namespace Nmro.IAM.Core.UseCases.Users.Commands
{
    public class CreateIdentityUserCommand: IRequest<int> {
       public CreatingUserModel Model {get; set;}
    }
}
