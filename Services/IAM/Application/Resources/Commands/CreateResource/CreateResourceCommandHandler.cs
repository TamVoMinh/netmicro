using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
using System.Linq;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, long>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public CreateResourceCommandHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            ApiResource apiResource = new ApiResource{
                Name = request.Model.Name,
                Enabled = request.Model.Enabled,
                DisplayName = request.Model.DisplayName,
                Description = request.Model.Description,
                UserClaims = request.Model.UserClaims,
                Scopes =  request.Model.Scopes.Select(x => new Scope{Name = x}).ToList()
            };

            await _context.ApiResources.AddAsync(apiResource);
            await _context.SaveChangesAsync(cancellationToken);

            return apiResource.Id;
        }
    }
}
