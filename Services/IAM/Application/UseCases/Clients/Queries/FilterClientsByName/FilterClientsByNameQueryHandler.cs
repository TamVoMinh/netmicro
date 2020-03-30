using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.UseCases.Clients.Mappers;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.UseCases.Clients.Models;

namespace Nmro.IAM.Application.UseCases.Clients.Queries
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
            IQueryable<Domain.Entities.Client> baseQuery = _context.Clients
                .Where(x => x.ClientName.Contains(request.Name));

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
