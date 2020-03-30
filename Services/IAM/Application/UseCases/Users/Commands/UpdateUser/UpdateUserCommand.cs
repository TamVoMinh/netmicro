using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand: IRequest<int> {
       public UpdatingUserModel Model {get; set;}
    }
}
