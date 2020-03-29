using MediatR;
using Nmro.IAM.Application.Users.Models;

namespace Nmro.IAM.Application.Users.Commands
{
    public class CreateUserCommand: IRequest<int> {
       public CreatingUserModel Model {get; set;}
    }
}
