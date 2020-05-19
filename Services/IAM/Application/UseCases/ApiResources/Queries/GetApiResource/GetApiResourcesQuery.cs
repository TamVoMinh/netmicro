using MediatR;
namespace Nmro.IAM.Application.UseCases.ApiResources.Queries
{
    public class GetApiResourcesQuery: IRequest<Models.ApiResource> {
        public long ResourceId { get; set;}
    }
}
