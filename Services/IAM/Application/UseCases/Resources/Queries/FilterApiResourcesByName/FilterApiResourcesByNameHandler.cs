using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class FilterApiResourcesByNameHandler : IRequestHandler<FilterApiResourcesByNameQuery, ListResult<Models.ApiResource>>
    {
        private readonly IIAMDbcontext _context;
        public FilterApiResourcesByNameHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<ListResult<Models.ApiResource>> Handle(FilterApiResourcesByNameQuery request, CancellationToken cancellationToken)
        {
             var query = string.IsNullOrEmpty(request.Name)
             ? _context.ApiResources
             : _context.ApiResources.Where(x => x.Name.Contains(request.Name));
            int count = await query.CountAsync();
            query.Skip(request.Offset).Take(request.Limit);
            var apiResources = await query.ToListAsync();
            var responseApiResources = apiResources.Select(item => item.ToModel());
            return new ListResult<Models.ApiResource> { Total = count, Data = responseApiResources };
        }
    }
}
