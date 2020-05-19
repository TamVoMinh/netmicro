using MediatR;

namespace Nmro.IAM.Application.UseCases.IdentityResources.Commands
{
    public class DeleteIdentityResourceCommand: IRequest<int>
    {
        public int IdentityResourceId { get; set; }
    }
}
