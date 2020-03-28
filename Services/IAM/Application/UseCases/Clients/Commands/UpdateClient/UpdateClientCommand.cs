using MediatR;
namespace Nmro.IAM.Application.UseCases.Clients.Commands
{
    public class UpdateClientCommand: IRequest<int>
    {
       public Models.UpdateClientModel Model {get;set;}
    }
}
