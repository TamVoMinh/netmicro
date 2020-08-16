using MediatR;
using Nmro.IAM.Core.UseCases.IdentityResources.Models;

namespace Nmro.IAM.Core.UseCases.IdentityResources.Queries
{
    public class FilterIdentityResourcesByNameQuery: IRequest<PageIdentityResource> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
