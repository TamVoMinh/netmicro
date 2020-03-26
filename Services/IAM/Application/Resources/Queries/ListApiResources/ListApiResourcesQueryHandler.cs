using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.Resources.Queries
{
    public class ListApiResourcesQueryHandler : IRequestHandler<ListApiResourcesQuery, ResponseListResult<ApiResourceModel>>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public ListApiResourcesQueryHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseListResult<ApiResourceModel>> Handle(ListApiResourcesQuery request, CancellationToken cancellationToken)
        {

             var query = string.IsNullOrEmpty(request.Name)
             ? _context.ApiResources
             : _context.ApiResources.Where(x => x.Name.Contains(request.Name) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(request.Offset).Take(request.Limit);

            var apiResources = await query.ToListAsync();

            var responseApiResources = _mapper.Map<List<ApiResourceModel>>(apiResources);

            return new ResponseListResult<ApiResourceModel> { Total = count, Data = responseApiResources };

        }
    }
}
