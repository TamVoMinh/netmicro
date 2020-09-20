using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.Aggregations.Dtos;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos.Mappers;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos.Mappers;

namespace Nmro.Security.IAM.Core.UseCases.Aggregations.Queries
{
    public class ListAllResourcesQueryHandler : IRequestHandler<ListAllResourcesQuery, Dtos.AllResources>
    {
        private readonly IIAMDbcontext _context;
        public ListAllResourcesQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<AllResources> Handle(ListAllResourcesQuery request, CancellationToken cancellationToken)
        {
             var identityResources = _context.IdentityResources
              .Include(x => x.UserClaims)
              .Include(x => x.Properties);

            var apiResources = _context.ApiResources
                .Include(x => x.Secrets)
                .Include(x => x.Scopes)
                .Include(x => x.UserClaims)
                .Include(x => x.Properties)
                .AsNoTracking();

            var apiScopes = _context.ApiScopes
                .Include(x => x.UserClaims)
                .Include(x => x.Properties)
                .AsNoTracking();

            var result = new Dtos.AllResources(
                (await identityResources.ToArrayAsync()).Select(x => x.ToModel()),
                (await apiResources.ToArrayAsync()).Select(x => x.ToModel()),
                (await apiScopes.ToArrayAsync()).Select(x => x.ToModel())
            );

            return result;
        }
    }
}
