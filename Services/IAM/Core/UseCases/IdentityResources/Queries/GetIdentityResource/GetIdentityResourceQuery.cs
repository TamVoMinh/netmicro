using MediatR;
namespace Nmro.IAM.Core.UseCases.IdentityResources.Queries
{
    public class GetIdentityResourceQuery: IRequest<Models.IdentityResource> {
        public long IdentityResourceId { get; set;}
    }
}
