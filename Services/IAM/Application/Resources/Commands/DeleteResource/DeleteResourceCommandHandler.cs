using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class DeleteResourceCommandHandler : IRequestHandler<DeleteResourceCommand, int>
    {

        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;

        public DeleteResourceCommandHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
        {
            ApiResource apiResource = await _context.ApiResources.FindAsync(request.Id);

            if(apiResource == null || apiResource.IsDeleted)
            {
                return int.MinValue;
            }

            apiResource.IsDeleted = true;

            _context.ApiResources.Update(apiResource);
            await _context.SaveChangesAsync(cancellationToken);

            return apiResource.Id;
        }
    }

}
