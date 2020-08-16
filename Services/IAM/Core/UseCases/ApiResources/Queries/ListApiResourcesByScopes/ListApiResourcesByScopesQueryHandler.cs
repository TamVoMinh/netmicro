using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Core.Interfaces;
using System.Collections.Generic;
using Nmro.IAM.Core.UseCases.ApiResources.Dtos.Mappers;

namespace Nmro.IAM.Core.UseCases.ApiResources.Queries
{
    public class ListApiResourcesByScopesQueryHandler : IRequestHandler<ListApiResourcesByScopesQuery, IEnumerable<Dtos.ApiResource>>
    {
        private readonly IIAMDbcontext _context;
        public ListApiResourcesByScopesQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Dtos.ApiResource>> Handle(ListApiResourcesByScopesQuery request, CancellationToken cancellationToken)
        {
            var names = request.Scopes.ToArray();

            var query =
                from api in _context.ApiResources
                where api.Scopes.Where(x => names.Contains(x.Scope)).Any()
                select api;

            var apis = query
                .Include(x => x.Secrets)
                .Include(x => x.Scopes)
                .Include(x => x.UserClaims)
                .Include(x => x.Properties)
                .AsNoTracking();

            var results = await apis.ToArrayAsync();
            var models = results.Select(x => x.ToModel()).ToArray();

            return models;
        }
    }
}
