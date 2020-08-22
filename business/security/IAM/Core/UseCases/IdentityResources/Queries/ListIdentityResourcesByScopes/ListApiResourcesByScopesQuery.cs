using System.Collections.Generic;
using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Queries
{
    public class ListIdentityResourcesByScopesQuery: IRequest<IEnumerable<Dtos.IdentityResource>> {
        public IEnumerable<string> Scopes { get; set;}
    }
}
