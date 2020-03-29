using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.Users.Models;

namespace Nmro.IAM.Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, IdentityUserModel>
    {
        private readonly IIAMDbcontext _context;
        public GetUserQueryHandler(IIAMDbcontext context)
        {
            _context = context;
        }

        public async Task<IdentityUserModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            return user == null ? null: user.ToModel();
        }
    }
}
