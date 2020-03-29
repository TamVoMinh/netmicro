using MediatR;
using Nmro.IAM.Application.Users.Models;

namespace Nmro.IAM.Application.Users.Commands
{
    public class UpdateUserCommand: IRequest<int> {
       public UpdatingUserModel Model {get; set;}
    }
}
