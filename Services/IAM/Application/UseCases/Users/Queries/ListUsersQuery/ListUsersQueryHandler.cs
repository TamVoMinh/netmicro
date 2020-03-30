using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Queries
{
    public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, PageIdentityUserModel>
    {
        private readonly IIAMDbcontext _context;
        public ListUsersQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<PageIdentityUserModel> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var query = string.IsNullOrEmpty(request.Email)
                ? _context.IdentityUsers.Where(x => !x.IsDeleted)
                : _context.IdentityUsers.Where(x => x.Email.Contains(request.Email) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(request.Offset).Take(request.Limit);

            var users = await query.ToListAsync();

            return  new PageIdentityUserModel (count, request.Limit, request.Offset, users.Select(x=> x.ToModel()));

        }
    }
}
