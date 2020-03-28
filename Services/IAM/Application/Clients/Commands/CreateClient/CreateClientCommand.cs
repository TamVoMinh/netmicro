using MediatR;
namespace Nmro.IAM.Application.Clients.Commands
{
    public class CreateClientCommand: IRequest<int>
    {
       public Models.CreateClientModel Model {get;set;}
    }
}
