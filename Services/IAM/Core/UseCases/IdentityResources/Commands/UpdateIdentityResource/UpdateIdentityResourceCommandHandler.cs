using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Domain.Entities;
using Nmro.IAM.Core.UseCases.IdentityResources.Models.Mappers;

namespace Nmro.IAM.Core.UseCases.IdentityResources.Commands
{
    public class UpdateIdentityResourceCommandHandler : IRequestHandler<UpdateIdentityResourceCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public UpdateIdentityResourceCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            IdentityResource identityResource =  await _context.IdentityResources.FindAsync(request.IdentityResourceId);
            if(identityResource != null){
                identityResource = request.Model.ToEntity();
            }
            _context.IdentityResources.Update(identityResource);
            await _context.SaveChangesAsync(cancellationToken);
            return identityResource.Id;
        }
    }
}
