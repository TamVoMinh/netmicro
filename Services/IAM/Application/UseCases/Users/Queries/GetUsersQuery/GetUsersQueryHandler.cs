using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, IdentityUser>
    {
        private readonly IIAMDbcontext _context;
        public GetUserQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<IdentityUser> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            return user == null ? null: user.ToModel();
        }
    }
}
