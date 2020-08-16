using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.ApiResources.Dtos.Mappers;
using Nmro.IAM.Core.Entities;
namespace Nmro.IAM.Core.UseCases.ApiResources.Commands
{
    public class UpdateResourceCommandHandler : IRequestHandler<UpdateApiResourceCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public UpdateResourceCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateApiResourceCommand request, CancellationToken cancellationToken)
        {
            ApiResource apiResourceEntity =  await _context.ApiResources.FindAsync(request.ApiResourceId);
            if(apiResourceEntity != null){
                apiResourceEntity = request.Model.ToEntity();
            }
            _context.ApiResources.Update(apiResourceEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return apiResourceEntity.Id;
        }
    }
}
