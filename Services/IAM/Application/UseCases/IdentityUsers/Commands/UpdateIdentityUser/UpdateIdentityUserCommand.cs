using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Commands
{
    public class UpdateIdentityUserCommand: IRequest<int> {
       public UpdatingUserModel Model {get; set;}
    }
}
