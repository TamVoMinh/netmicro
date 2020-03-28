using MediatR;
namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class FilterApiResourcesByNameQuery: IRequest<ListResult<Models.ApiResource>> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
