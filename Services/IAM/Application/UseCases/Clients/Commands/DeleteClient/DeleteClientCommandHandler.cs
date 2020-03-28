using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.UseCases.Clients.Commands
{
    public class DeleteClientCommandHandler: IRequestHandler<DeleteClientCommand, int>
    {
        IIAMDbcontext _context;
        public DeleteClientCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client client = await _context.Clients.FindAsync(request.Id);

            if(client == null){
                return int.MinValue;
            }

            _context.Clients.Remove(client);

            int effected = await _context.SaveChangesAsync(cancellationToken);

            return effected > 0 ? client.Id : int.MinValue;
        }
    }
}
