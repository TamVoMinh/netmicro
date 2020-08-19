using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Commands
{
    public class UpdateIdentityResourceCommand: IRequest<int>
    {
        public int IdentityResourceId {get; set;}
        public Dtos.IdentityResource Model {get; set;}
    }
}
