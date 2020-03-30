using MediatR;
using Nmro.IAM.Application.UseCases.Resources.Models;

namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class FilterIdentityResourcesByNameQuery: IRequest<PageIdentityResource> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
