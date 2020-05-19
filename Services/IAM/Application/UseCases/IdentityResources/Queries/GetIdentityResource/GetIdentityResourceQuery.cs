using MediatR;
namespace Nmro.IAM.Application.UseCases.IdentityResources.Queries
{
    public class GetIdentityResourceQuery: IRequest<Models.IdentityResource> {
        public long IdentityResourceId { get; set;}
    }
}
