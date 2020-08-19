using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.Security.IAM.Core.Interfaces;
using System.Collections.Generic;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos.Mappers;

namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Queries
{
    public class ListIdentityResourcesByScopesQueryHandler : IRequestHandler<ListIdentityResourcesByScopesQuery, IEnumerable<Dtos.IdentityResource>>
    {
        private readonly IIAMDbcontext _context;
        public ListIdentityResourcesByScopesQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Dtos.IdentityResource>> Handle(ListIdentityResourcesByScopesQuery request, CancellationToken cancellationToken)
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
