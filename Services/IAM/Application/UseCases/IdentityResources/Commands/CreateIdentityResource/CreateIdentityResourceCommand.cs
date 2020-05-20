using MediatR;
using Nmro.IAM.Application.UseCases.IdentityResources.Models;
namespace Nmro.IAM.Application.UseCases.IdentityResources.Commands
{
    public class CreateIdentityResourceCommand: IRequest<int>
    {
        public IdentityResource Model;
    }
}
