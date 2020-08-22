using MediatR;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos;
namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Commands
{
    public class CreateIdentityResourceCommand: IRequest<int>
    {
        public IdentityResource Model;
    }
}
