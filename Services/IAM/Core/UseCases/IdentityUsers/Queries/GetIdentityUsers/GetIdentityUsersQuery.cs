using MediatR;
using Nmro.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.IAM.Core.UseCases.Users.Queries
{
    public class GetIdentityUsersQuery: IRequest<IdentityUser> {
        public long UserId { get; set;}
    }
}
