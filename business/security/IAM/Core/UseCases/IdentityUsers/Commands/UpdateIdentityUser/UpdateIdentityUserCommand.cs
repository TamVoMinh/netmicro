using MediatR;
using Nmro.Security.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.Users.Commands
{
    public class UpdateIdentityUserCommand: IRequest<int> {
       public UpdatingUserModel Model {get; set;}
    }
}
