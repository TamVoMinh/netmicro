using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.UseCases.Clients.Mappers;

namespace Nmro.IAM.Application.UseCases.Clients.Commands
{
    public class CreateClientCommandHandler: IRequestHandler<CreateClientCommand, int>
    {
        IIAMDbcontext _context;
        public CreateClientCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client client = request.Model.ToEntity();

            await _context.Clients.AddAsync(client);
            int effected = await _context.SaveChangesAsync(cancellationToken);

            return effected > 0 ? client.Id : int.MinValue;
        }
    }
}
