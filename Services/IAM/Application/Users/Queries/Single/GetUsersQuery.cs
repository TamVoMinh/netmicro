using MediatR;
namespace Nmro.IAM.Application.Users.Queries
{
    public class GetUsersQuery: IRequest<IdentityUserModel> {
        public long UserId { get; set;}
    }
}
