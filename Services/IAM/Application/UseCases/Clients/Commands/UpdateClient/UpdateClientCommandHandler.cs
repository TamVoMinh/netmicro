using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.UseCases.Clients.Models.Mappers;

namespace Nmro.IAM.Application.UseCases.Clients.Commands
{
    public class UpdateClientCommandHandler: IRequestHandler<UpdateClientCommand, int>
    {
        IIAMDbcontext _context;
        public UpdateClientCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client client = await _context.Clients.FindAsync(request.Model.Id);

            if(client == null){
                return int.MinValue;
            }

            _context.Clients.Update(request.Model.ToUpdateEntity(client));

            int effected = await _context.SaveChangesAsync(cancellationToken);

            return effected > 0 ? client.Id : int.MinValue;
        }
    }
}
