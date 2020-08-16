using MediatR;

namespace Nmro.IAM.Core.UseCases.ApiResources.Commands
{
    public class DeleteApiResourceCommand: IRequest<int>
    {
        public int ApiResourceId { get; set; }
    }
}
