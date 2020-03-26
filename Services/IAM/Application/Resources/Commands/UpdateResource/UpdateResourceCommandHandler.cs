using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
using System.Linq;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class UpdateResourceCommandHandler : IRequestHandler<UpdateResourceCommand, long>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public UpdateResourceCommandHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Handle(UpdateResourceCommand request, CancellationToken cancellationToken)
        {

            ApiResource apiResource =  await _context.ApiResources.FindAsync(request.Model.Id);

            if(apiResource != null){

                apiResource.Name = string.IsNullOrEmpty(request.Model.Name) ?  apiResource.Name : request.Model.Name;
                apiResource.Enabled = request.Model.Enabled ?? apiResource.Enabled;
                apiResource.DisplayName = request.Model.DisplayName ?? apiResource.DisplayName;
                apiResource.Description = request.Model.Description ?? apiResource.Description;
                apiResource.UserClaims = request.Model.UserClaims ?? apiResource.UserClaims;
                apiResource.Scopes =  request.Model.Scopes != null ? request.Model.Scopes.Select(x => new Scope{Name = x}).ToList() : apiResource.Scopes;
            }

            _context.ApiResources.Update(apiResource);
            await _context.SaveChangesAsync(cancellationToken);

            return apiResource.Id;
        }
    }
}
