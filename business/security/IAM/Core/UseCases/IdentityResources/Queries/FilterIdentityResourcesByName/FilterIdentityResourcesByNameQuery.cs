using MediatR;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Queries
{
    public class FilterIdentityResourcesByNameQuery: IRequest<PageIdentityResource> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
