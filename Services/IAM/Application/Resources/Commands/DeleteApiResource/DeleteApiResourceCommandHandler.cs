using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.Resources.Commands
{
    public class DeleteApiResourceCommandHandler : IRequestHandler<DeleteApiResourceCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public DeleteApiResourceCommandHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
