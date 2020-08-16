using System.Collections.Generic;
using MediatR;
namespace Nmro.IAM.Core.UseCases.IdentityResources.Queries
{
    public class ListIdentityResourcesByScopesQuery: IRequest<IEnumerable<Models.IdentityResource>> {
        public IEnumerable<string> Scopes { get; set;}
    }
}
