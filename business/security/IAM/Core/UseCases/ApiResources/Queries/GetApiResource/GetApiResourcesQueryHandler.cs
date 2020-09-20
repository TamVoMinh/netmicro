using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos.Mappers;

namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Queries
{
    public class GetApiResourcesQueryHandler : IRequestHandler<GetApiResourcesQuery, Dtos.ApiResource>
    {
        private readonly IIAMDbcontext _context;
        public GetApiResourcesQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<Dtos.ApiResource> Handle(GetApiResourcesQuery request, CancellationToken cancellationToken)
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
