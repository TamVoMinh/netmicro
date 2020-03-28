using MediatR;
namespace Nmro.IAM.Application.UseCases.Clients.Commands
{
    public class DeleteClientCommand: IRequest<int>
    {
        public int Id {get; set;}
    }
}
