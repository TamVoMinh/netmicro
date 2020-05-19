using MediatR;

namespace Nmro.IAM.Application.UseCases.ApiResources.Commands
{
    public class DeleteApiResourceCommand: IRequest<int>
    {
        public int ApiResourceId { get; set; }
    }
}
