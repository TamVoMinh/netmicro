using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Core.UseCases.Clients.Models.Mappers;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.Clients.Models;

namespace Nmro.IAM.Core.UseCases.Clients.Queries
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
            IQueryable<Domain.Entities.Client> baseQuery = _context.Clients.Include(x => x.AllowedGrantTypes);

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
