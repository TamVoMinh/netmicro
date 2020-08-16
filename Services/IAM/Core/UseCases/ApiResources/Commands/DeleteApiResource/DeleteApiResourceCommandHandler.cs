using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.Entities;
namespace Nmro.IAM.Core.UseCases.ApiResources.Commands
{
    public class DeleteApiResourceCommandHandler : IRequestHandler<DeleteApiResourceCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public DeleteApiResourceCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteApiResourceCommand request, CancellationToken cancellationToken)
        {
            ApiResource apiResource = await _context.ApiResources.FindAsync(request.ApiResourceId);
            if(apiResource == null)
            {
                return int.MinValue;
            }
            _context.ApiResources.Remove(apiResource);
            int effected = await _context.SaveChangesAsync(cancellationToken);
            return request.ApiResourceId;
        }
    }
}
