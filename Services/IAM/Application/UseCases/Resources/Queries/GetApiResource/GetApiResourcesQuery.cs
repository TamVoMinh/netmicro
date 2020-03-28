using MediatR;
namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class GetApiResourcesQuery: IRequest<Models.ApiResource> {
        public long ResourceId { get; set;}
    }
}
