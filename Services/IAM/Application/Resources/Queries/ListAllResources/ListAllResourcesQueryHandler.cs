using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.Resources.Queries
{
    public class ListAllResourcesQueryHandler : IRequestHandler<ListAllResourcesQuery, Models.AllResources>
    {
        private readonly IIAMDbcontext _context;
        public ListAllResourcesQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<Models.AllResources> Handle(ListAllResourcesQuery request, CancellationToken cancellationToken)
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

            var result = new Models.AllResources(
                (await identityResources.ToArrayAsync()).Select(x => x.ToModel()),
                (await apiResources.ToArrayAsync()).Select(x => x.ToModel()),
                (await apiScopes.ToArrayAsync()).Select(x => x.ToModel())
            );

            return result;
        }
    }
}
