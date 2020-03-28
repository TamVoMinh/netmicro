using MediatR;
namespace Nmro.IAM.Application.Resources.Queries
{
    public class GetIdentityResourceQuery: IRequest<Models.IdentityResource> {
        public long IdentityResourceId { get; set;}
    }
}
