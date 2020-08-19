using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.Clients.Commands
{
    public class UpdateClientCommand: IRequest<int>
    {
       public Dtos.UpdateClientModel Model {get;set;}
    }
}
