using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.ApiResources.Models.Mappers;

namespace Nmro.IAM.Core.UseCases.ApiResources.Queries
{
    public class GetApiResourcesQueryHandler : IRequestHandler<GetApiResourcesQuery, Models.ApiResource>
    {
        private readonly IIAMDbcontext _context;
        public GetApiResourcesQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<Models.ApiResource> Handle(GetApiResourcesQuery request, CancellationToken cancellationToken)
        {
              var apiResource = await _context.ApiResources
                .Where(e => e.Id == request.ResourceId)
                .Include(e => e.Secrets)
                .Include(e => e.Scopes)
                .Include(x => x.UserClaims)
                .Include(x => x.Properties)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return apiResource == null ? null : apiResource.ToModel();
        }
    }
}
