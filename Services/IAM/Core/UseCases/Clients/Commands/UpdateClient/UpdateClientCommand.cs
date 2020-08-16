using MediatR;
namespace Nmro.IAM.Core.UseCases.Clients.Commands
{
    public class UpdateClientCommand: IRequest<int>
    {
       public Dtos.UpdateClientModel Model {get;set;}
    }
}
