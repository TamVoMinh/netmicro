using MediatR;
using Nmro.IAM.Application.UseCases.IdentityResources.Models;

namespace Nmro.IAM.Application.UseCases.IdentityResources.Queries
{
    public class FilterIdentityResourcesByNameQuery: IRequest<PageIdentityResource> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
