using MediatR;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class DeleteResourceCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
