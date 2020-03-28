using MediatR;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class DeleteApiResourceCommand: IRequest<int>
    {
        public int ApiResourceId { get; set; }
    }
}
