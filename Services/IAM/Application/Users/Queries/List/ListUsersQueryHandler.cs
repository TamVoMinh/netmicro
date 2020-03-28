using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.Users.Models;

namespace Nmro.IAM.Application.Users.Queries
{
    public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, ResponseListResult<IdentityUserModel>>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        public ListUsersQueryHandler(IIAMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseListResult<IdentityUserModel>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var query = string.IsNullOrEmpty(request.Email)
                ? _context.IdentityUsers.Where(x => !x.IsDeleted)
                : _context.IdentityUsers.Where(x => x.Email.Contains(request.Email) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(request.Offset).Take(request.Limit);

            var users = await query.ToListAsync();

            var responseUsers = _mapper.Map<List<IdentityUserModel>>(users);

            return  new ResponseListResult<IdentityUserModel> { Total = count , Data = responseUsers };

        }
    }
}
