using MediatR;
using Nmro.IAM.Core.UseCases.IdentityResources.Models;
namespace Nmro.IAM.Core.UseCases.IdentityResources.Commands
{
    public class CreateIdentityResourceCommand: IRequest<int>
    {
        public IdentityResource Model;
    }
}
