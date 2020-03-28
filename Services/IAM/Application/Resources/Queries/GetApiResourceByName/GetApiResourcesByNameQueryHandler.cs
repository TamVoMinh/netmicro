using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
namespace Nmro.IAM.Application.Resources.Queries
{
    public class GetApiResourceByNameQueryHandler : IRequestHandler<GetApiResourceByNameQuery, Models.ApiResource>
    {
        private readonly IIAMDbcontext _context;

        public GetApiResourceByNameQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<Models.ApiResource> Handle(GetApiResourceByNameQuery request, CancellationToken cancellationToken)
        {
              var apiResource = await _context.ApiResources
                .Where(e => e.Name.Equals(request.Name))
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
