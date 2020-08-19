using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.Security.IAM.Core.UseCases.Clients.Dtos.Mappers;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.Clients.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.Clients.Queries
{
    public class FilterClientsByNameQueryHandler: IRequestHandler<FilterClientsByNameQuery, PageClient>
    {
        IIAMDbcontext _context;
        public FilterClientsByNameQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<PageClient> Handle(FilterClientsByNameQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Core.Entities.Client> baseQuery = _context.Clients.Include(x => x.AllowedGrantTypes);

            if(!string.IsNullOrEmpty(request.Name))
                baseQuery.Where(x => x.ClientName.Contains(request.Name));

            int count = await baseQuery.CountAsync();

            var clients = await baseQuery
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToArrayAsync();

            int pageSize = clients.Count();

            return new PageClient(count, request.Offset, request.Limit, clients.Select(x=>x.ToModel()));
        }
    }
}
