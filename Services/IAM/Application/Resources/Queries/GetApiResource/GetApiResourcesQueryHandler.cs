using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using System.Linq;

namespace Nmro.IAM.Application.Resources.Queries
{
    public class GetApiResourcesQueryHandler : IRequestHandler<GetApiResourcesQuery, ApiResourceModel>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public GetApiResourcesQueryHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResourceModel> Handle(GetApiResourcesQuery request, CancellationToken cancellationToken)
        {

              var apiResource = await _context.ApiResources
                .Where(e => e.Id == request.ResourceId && !e.IsDeleted)
                .Include(e => e.ApiSecrets)
                .Include(e => e.Scopes)
                .FirstOrDefaultAsync();

            return apiResource == null ? null : _mapper.Map<ApiResourceModel>(apiResource);
        }
    }
}
