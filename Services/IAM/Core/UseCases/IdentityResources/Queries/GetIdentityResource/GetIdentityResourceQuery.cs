using MediatR;
namespace Nmro.IAM.Core.UseCases.IdentityResources.Queries
{
    public class GetIdentityResourceQuery: IRequest<Dtos.IdentityResource> {
        public long IdentityResourceId { get; set;}
    }
}
