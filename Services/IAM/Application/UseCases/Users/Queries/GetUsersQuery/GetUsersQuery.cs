using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Queries
{
    public class GetUsersQuery: IRequest<IdentityUser> {
        public long UserId { get; set;}
    }
}
