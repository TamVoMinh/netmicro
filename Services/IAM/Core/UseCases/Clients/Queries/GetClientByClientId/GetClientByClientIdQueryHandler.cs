using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.Clients.Models.Mappers;

namespace Nmro.IAM.Core.UseCases.Clients.Queries
{
    public class GetClientByClientIdQueryHandler : IRequestHandler<GetClientByClientIdQuery, Models.Client>
    {
        private readonly IIAMDbcontext _context;
        public GetClientByClientIdQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<Models.Client> Handle(GetClientByClientIdQuery request, CancellationToken cancellationToken)
        {
           IQueryable<Domain.Entities.Client> baseQuery = _context.Clients
                .Where(x => x.ClientId == request.ClientId)
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
