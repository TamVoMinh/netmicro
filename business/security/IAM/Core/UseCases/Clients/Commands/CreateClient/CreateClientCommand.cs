using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.Clients.Commands
{
    public class CreateClientCommand: IRequest<int>
    {
       public Dtos.CreateClientModel Model {get;set;}
    }
}
