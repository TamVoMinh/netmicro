using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using System.Collections.Generic;

namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class ListIdentityResourcesByScopesQueryHandler : IRequestHandler<ListIdentityResourcesByScopesQuery, IEnumerable<Models.IdentityResource>>
    {
        private readonly IIAMDbcontext _context;
        public ListIdentityResourcesByScopesQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Models.IdentityResource>> Handle(ListIdentityResourcesByScopesQuery request, CancellationToken cancellationToken)
        {
             var scopes = request.Scopes.ToArray();

            var query =
                from identityResource in _context.IdentityResources
                where scopes.Contains(identityResource.Name)
                select identityResource;

            var resources = query
                .Include(x => x.UserClaims)
                .Include(x => x.Properties)
                .AsNoTracking();

            var results = await resources.ToArrayAsync();

            var models = results.Select(x => x.ToModel()).ToArray();

            return models;
        }
    }
}
