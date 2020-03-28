using MediatR;
using Nmro.IAM.Application.Resources.Models;
namespace Nmro.IAM.Application.Resources.Commands
{
    public class CreateIdentityResourceCommand: IRequest<int>
    {
        public IdentityResource Model;
    }
}
