using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Queries
{
    public class GetIdentityResourceQuery: IRequest<Dtos.IdentityResource> {
        public long IdentityResourceId { get; set;}
    }
}
