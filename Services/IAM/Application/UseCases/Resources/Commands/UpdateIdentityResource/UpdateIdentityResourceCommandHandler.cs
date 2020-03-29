using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.UseCases.Resources.Commands
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
