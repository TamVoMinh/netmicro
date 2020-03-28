using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.Clients.Mappers;

namespace Nmro.IAM.Application.Clients.Queries
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, Models.Client>
    {
        private readonly IIAMDbcontext _context;
        public GetClientQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<Models.Client> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
           IQueryable<Domain.Entities.Client> baseQuery = _context.Clients
            .Where(x => x.Id == request.Id)
            .Take(1);

            var client = await baseQuery.FirstOrDefaultAsync();
            if (client == null) return null;

            await baseQuery.Include(x => x.AllowedCorsOrigins).SelectMany(c => c.AllowedCorsOrigins).LoadAsync();
            await baseQuery.Include(x => x.AllowedGrantTypes).SelectMany(c => c.AllowedGrantTypes).LoadAsync();
            await baseQuery.Include(x => x.AllowedScopes).SelectMany(c => c.AllowedScopes).LoadAsync();
            await baseQuery.Include(x => x.Claims).SelectMany(c => c.Claims).LoadAsync();
            await baseQuery.Include(x => x.ClientSecrets).SelectMany(c => c.ClientSecrets).LoadAsync();
            await baseQuery.Include(x => x.IdentityProviderRestrictions).SelectMany(c => c.IdentityProviderRestrictions).LoadAsync();
            await baseQuery.Include(x => x.PostLogoutRedirectUris).SelectMany(c => c.PostLogoutRedirectUris).LoadAsync();
            await baseQuery.Include(x => x.Properties).SelectMany(c => c.Properties).LoadAsync();
            await baseQuery.Include(x => x.RedirectUris).SelectMany(c => c.RedirectUris).LoadAsync();

            var model = client.ToModel();

            return model;
        }
    }
}
