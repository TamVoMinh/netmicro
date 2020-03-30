using MediatR;
using Nmro.IAM.Application.UseCases.Resources.Models;

namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class FilterApiResourcesByNameQuery: IRequest<PageApiResource> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
