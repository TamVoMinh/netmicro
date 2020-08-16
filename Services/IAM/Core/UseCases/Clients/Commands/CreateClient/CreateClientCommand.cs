using MediatR;
namespace Nmro.IAM.Core.UseCases.Clients.Commands
{
    public class CreateClientCommand: IRequest<int>
    {
       public Dtos.CreateClientModel Model {get;set;}
    }
}
