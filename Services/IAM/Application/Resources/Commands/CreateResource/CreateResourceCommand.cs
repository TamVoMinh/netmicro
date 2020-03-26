using MediatR;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class UpdateResourceCommand: IRequest<long>
    {
        public UpdateResourceModel Model;
    }
}
