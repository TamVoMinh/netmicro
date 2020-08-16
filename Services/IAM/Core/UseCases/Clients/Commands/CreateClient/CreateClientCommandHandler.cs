using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.Clients.Dtos.Mappers;

namespace Nmro.IAM.Core.UseCases.Clients.Commands
{
    public class CreateClientCommandHandler: IRequestHandler<CreateClientCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public CreateClientCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            Core.Entities.Client client = request.Model.ToEntity();

            await _context.Clients.AddAsync(client);
            int effected = await _context.SaveChangesAsync(cancellationToken);

            return effected > 0 ? client.Id : int.MinValue;
        }
    }
}
