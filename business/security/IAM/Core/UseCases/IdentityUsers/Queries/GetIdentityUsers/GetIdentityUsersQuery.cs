using MediatR;
using Nmro.Security.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.Users.Queries
{
    public class GetIdentityUsersQuery: IRequest<IdentityUser> {
        public long UserId { get; set;}
    }
}
