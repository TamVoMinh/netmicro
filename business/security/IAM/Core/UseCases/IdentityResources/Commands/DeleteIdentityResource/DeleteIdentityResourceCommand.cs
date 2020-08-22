using MediatR;

namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Commands
{
    public class DeleteIdentityResourceCommand: IRequest<int>
    {
        public int IdentityResourceId { get; set; }
    }
}
