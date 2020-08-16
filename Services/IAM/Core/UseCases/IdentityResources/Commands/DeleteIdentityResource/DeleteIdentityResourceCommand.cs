using MediatR;

namespace Nmro.IAM.Core.UseCases.IdentityResources.Commands
{
    public class DeleteIdentityResourceCommand: IRequest<int>
    {
        public int IdentityResourceId { get; set; }
    }
}
