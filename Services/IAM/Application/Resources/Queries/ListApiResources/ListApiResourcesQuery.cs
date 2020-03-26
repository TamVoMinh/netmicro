using MediatR;
namespace Nmro.IAM.Application.Resources.Queries
{
    public class ListApiResourcesQuery: IRequest<ResponseListResult<ApiResourceModel>> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
