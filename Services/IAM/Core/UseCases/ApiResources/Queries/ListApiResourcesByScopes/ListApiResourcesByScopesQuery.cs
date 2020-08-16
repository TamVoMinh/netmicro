using System.Collections.Generic;
using MediatR;
namespace Nmro.IAM.Core.UseCases.ApiResources.Queries
{
    public class ListApiResourcesByScopesQuery: IRequest<IEnumerable<Models.ApiResource>> {
        public IEnumerable<string> Scopes { get; set;}
    }
}
