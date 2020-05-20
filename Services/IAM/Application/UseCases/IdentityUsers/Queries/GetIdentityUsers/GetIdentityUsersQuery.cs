using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Queries
{
    public class GetIdentityUsersQuery: IRequest<IdentityUser> {
        public long UserId { get; set;}
    }
}
