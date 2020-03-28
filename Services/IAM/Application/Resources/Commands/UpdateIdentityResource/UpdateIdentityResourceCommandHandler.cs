using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.Resources.Commands
{
    public class UpdateIdentityResourceCommandHandler : IRequestHandler<UpdateIdentityResourceCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public UpdateIdentityResourceCommandHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
