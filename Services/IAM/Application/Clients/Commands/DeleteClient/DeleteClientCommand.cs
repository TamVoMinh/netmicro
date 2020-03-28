using MediatR;
namespace Nmro.IAM.Application.Clients.Commands
{
    public class DeleteClientCommand: IRequest<int>
    {
        public int Id {get; set;}
    }
}
