using MediatR;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.Application.UseCases.Users.Queries
{
    public class ListUsersQuery:IRequest<PageIdentityUserModel> {
        public string Email { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
