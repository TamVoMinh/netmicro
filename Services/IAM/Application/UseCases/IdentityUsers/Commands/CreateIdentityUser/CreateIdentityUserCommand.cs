using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Commands
{
    public class CreateIdentityUserCommand: IRequest<int> {
       public CreatingUserModel Model {get; set;}
    }
}
