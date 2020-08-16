using MediatR;
namespace Nmro.IAM.Core.UseCases.Clients.Commands
{
    public class DeleteClientCommand: IRequest<int>
    {
        public int Id {get; set;}
    }
}
