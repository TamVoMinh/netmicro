using MediatR;

namespace Nmro.IAM.Application.UseCases.Resources.Commands
{
    public class DeleteApiResourceCommand: IRequest<int>
    {
        public int ApiResourceId { get; set; }
    }
}
