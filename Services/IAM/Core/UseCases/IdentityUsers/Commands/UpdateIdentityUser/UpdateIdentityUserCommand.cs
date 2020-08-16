using MediatR;
using Nmro.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.IAM.Core.UseCases.Users.Commands
{
    public class UpdateIdentityUserCommand: IRequest<int> {
       public UpdatingUserModel Model {get; set;}
    }
}
