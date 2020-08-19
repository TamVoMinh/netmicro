using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.Clients.Commands
{
    public class DeleteClientCommand: IRequest<int>
    {
        public int Id {get; set;}
    }
}
