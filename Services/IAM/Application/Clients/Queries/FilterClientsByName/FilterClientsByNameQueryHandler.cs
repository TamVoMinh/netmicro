using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Clients.Mappers;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.Clients.Queries
{
    public class FilterClientsByNameQueryHandler: IRequestHandler<FilterClientsByNameQuery, ResponseListResult<Models.Client>>
    {
        IIAMDbcontext _context;
        public FilterClientsByNameQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<ResponseListResult<Models.Client>> Handle(FilterClientsByNameQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Client> baseQuery = _context.Clients
                .Where(x => x.ClientName.Contains(request.Name));

            int count = await baseQuery.CountAsync();

            var clients = await baseQuery
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToArrayAsync();

            return new ResponseListResult<Models.Client>{ Total = count, Data = clients.Select(x=>x.ToModel())};
        }
    }
}
