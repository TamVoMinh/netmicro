using MediatR;
using Nmro.Security.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.Users.Queries
{
    public class ListIdentityUsersQuery:IRequest<PageIdentityUserModel> {
        public string Email { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
