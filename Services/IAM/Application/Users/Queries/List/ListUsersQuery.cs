using MediatR;
using Nmro.IAM.Application.Users.Models;

namespace Nmro.IAM.Application.Users.Queries
{
    public class ListUsersQuery:IRequest<ResponseListResult<IdentityUserModel>> {
        public string Email { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
