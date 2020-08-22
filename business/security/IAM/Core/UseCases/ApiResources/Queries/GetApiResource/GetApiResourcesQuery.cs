using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Queries
{
    public class GetApiResourcesQuery: IRequest<Dtos.ApiResource> {
        public long ResourceId { get; set;}
    }
}
