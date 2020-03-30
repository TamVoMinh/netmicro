using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Commands
{
    public class CreateUserCommand: IRequest<int> {
       public CreatingUserModel Model {get; set;}
    }
}
