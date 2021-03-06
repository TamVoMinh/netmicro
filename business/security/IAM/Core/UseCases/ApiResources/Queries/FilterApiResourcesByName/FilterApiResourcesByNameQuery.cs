using MediatR;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Queries
{
    public class FilterApiResourcesByNameQuery: IRequest<PageApiResource> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
