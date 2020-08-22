using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos.Mappers;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Commands
{
    public class CreateIdentityResourceCommandHandler: IRequestHandler<CreateIdentityResourceCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public CreateIdentityResourceCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            IdentityResource identityResource = request.Model.ToEntity();
            await _context.IdentityResources.AddAsync(identityResource);
            await _context.SaveChangesAsync(cancellationToken);
            return identityResource.Id;
        }
    }
}
