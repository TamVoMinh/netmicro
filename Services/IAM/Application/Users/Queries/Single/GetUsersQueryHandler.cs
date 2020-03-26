using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, IdentityUserModel>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IdentityUserModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            return user == null? null:   _mapper.Map<IdentityUserModel>(user);
        }
    }
}
