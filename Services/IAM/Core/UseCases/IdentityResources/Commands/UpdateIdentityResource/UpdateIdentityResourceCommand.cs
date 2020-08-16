using MediatR;
namespace Nmro.IAM.Core.UseCases.IdentityResources.Commands
{
    public class UpdateIdentityResourceCommand: IRequest<int>
    {
        public int IdentityResourceId {get; set;}
        public Models.IdentityResource Model {get; set;}
    }
}
