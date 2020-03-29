using MediatR;
namespace Nmro.IAM.Application.UseCases.Clients.Commands
{
    public class CreateClientCommand: IRequest<int>
    {
       public Models.CreateClientModel Model {get;set;}
    }
}
