using MediatR;

namespace Nmro.IAM.Application.UseCases.Resources.Commands
{
    public class DeleteIdentityResourceCommand: IRequest<int>
    {
        public int IdentityResourceId { get; set; }
    }
}
