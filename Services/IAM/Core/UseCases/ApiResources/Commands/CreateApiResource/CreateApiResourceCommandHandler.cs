using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.ApiResources.Models.Mappers;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Core.UseCases.ApiResources.Commands
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
