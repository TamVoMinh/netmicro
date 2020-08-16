using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.Users.Models;

namespace Nmro.IAM.Core.UseCases.Users.Queries
{
    public class GetIdentityUsersQueryHandler : IRequestHandler<GetIdentityUsersQuery, IdentityUser>
    {
        private readonly IIAMDbcontext _context;
        public GetIdentityUsersQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<IdentityUser> Handle(GetIdentityUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            return user == null ? null: user.ToModel();
        }
    }
}
