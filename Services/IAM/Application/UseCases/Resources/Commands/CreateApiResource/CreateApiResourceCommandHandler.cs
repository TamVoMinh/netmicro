using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.UseCases.Resources.Commands
{
    public class CreateApiResourceCommandHandler : IRequestHandler<CreateApiResourceCommand, long>
    {
        private readonly IIAMDbcontext _context;
        public CreateApiResourceCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateApiResourceCommand request, CancellationToken cancellationToken)
        {
            ApiResource apiResource = request.Model.ToEntity();
            await _context.ApiResources.AddAsync(apiResource);
            await _context.SaveChangesAsync(cancellationToken);
            return apiResource.Id;
        }
    }
}
