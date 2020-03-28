using MediatR;
namespace Nmro.IAM.Application.Resources.Queries
{
    public class FilterApiResourcesByNameQuery: IRequest<ResponseListResult<Models.ApiResource>> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
