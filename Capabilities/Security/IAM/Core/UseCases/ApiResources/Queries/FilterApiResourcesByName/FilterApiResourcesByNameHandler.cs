using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos.Mappers;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Queries
{
    public class FilterApiResourcesByNameHandler : IRequestHandler<FilterApiResourcesByNameQuery, PageApiResource>
    {
        private readonly IIAMDbcontext _context;
        public FilterApiResourcesByNameHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<PageApiResource> Handle(FilterApiResourcesByNameQuery request, CancellationToken cancellationToken)
        {
             var query = string.IsNullOrEmpty(request.Name)
             ? _context.ApiResources
             : _context.ApiResources.Where(x => x.Name.Contains(request.Name));

            int count = await query.CountAsync();

            query.Skip(request.Offset).Take(request.Limit);
            var apiResources = await query.ToListAsync();

            return new PageApiResource(count, request.Offset, request.Limit, apiResources.Select(item => item.ToModel()));
        }
    }
}
