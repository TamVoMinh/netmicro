using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.UseCases.Resources.Commands
{
    public class DeleteIdentityResourceCommandHandler : IRequestHandler<DeleteIdentityResourceCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public DeleteIdentityResourceCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            IdentityResource identityResource = await _context.IdentityResources.FindAsync(request.IdentityResourceId);
            if(identityResource == null)
            {
                return int.MinValue;
            }
            _context.IdentityResources.Remove(identityResource);
            int effected = await _context.SaveChangesAsync(cancellationToken);
            return request.IdentityResourceId;
        }
    }
}
