using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.UseCases.IdentityResources.Models.Mappers;

namespace Nmro.IAM.Application.UseCases.IdentityResources.Queries
{
    public class GetIdentityResourceQueryHandler : IRequestHandler<GetIdentityResourceQuery, Models.IdentityResource>
    {
        private readonly IIAMDbcontext _context;
        public GetIdentityResourceQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<Models.IdentityResource> Handle(GetIdentityResourceQuery request, CancellationToken cancellationToken)
        {
              var identityResource = await _context.IdentityResources
                .Where(e => e.Id == request.IdentityResourceId)
                .Include(x => x.UserClaims)
                .Include(x => x.Properties)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return identityResource == null ? null : identityResource.ToModel();
        }
    }
}
