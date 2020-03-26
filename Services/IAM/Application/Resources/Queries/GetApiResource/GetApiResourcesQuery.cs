using MediatR;
namespace Nmro.IAM.Application.Resources.Queries
{
    public class GetApiResourcesQuery: IRequest<ApiResourceModel> {
        public long ResourceId { get; set;}
    }
}
