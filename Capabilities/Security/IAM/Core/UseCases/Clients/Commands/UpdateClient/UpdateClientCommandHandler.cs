using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.Clients.Dtos.Mappers;

namespace Nmro.Security.IAM.Core.UseCases.Clients.Commands
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
            Core.Entities.Client client = await _context.Clients.FindAsync(request.Model.Id);

            if(client == null){
                return int.MinValue;
            }

            _context.Clients.Update(request.Model.ToUpdateEntity(client));

            int effected = await _context.SaveChangesAsync(cancellationToken);

            return effected > 0 ? client.Id : int.MinValue;
        }
    }
}
