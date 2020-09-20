using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos.Mappers;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Queries
{
    public class FilterIdentityResourcesByNameHandler : IRequestHandler<FilterIdentityResourcesByNameQuery, PageIdentityResource>
    {
        private readonly IIAMDbcontext _context;
        public FilterIdentityResourcesByNameHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<PageIdentityResource> Handle(FilterIdentityResourcesByNameQuery request, CancellationToken cancellationToken)
        {
            var query = string.IsNullOrEmpty(request.Name)
                ? _context.IdentityResources
                : _context.IdentityResources.Where(x => x.Name.Contains(request.Name));

            int count = await query.CountAsync();
            query.Skip(request.Offset).Take(request.Limit);
            var identityResources = await query.ToListAsync();
            var responseApiResources = identityResources.Select(item => item.ToModel());
            return new PageIdentityResource(count, request.Offset, request.Limit,  responseApiResources );
        }
    }
}
