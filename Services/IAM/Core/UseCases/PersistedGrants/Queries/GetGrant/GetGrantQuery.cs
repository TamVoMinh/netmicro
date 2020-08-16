using System.Collections.Generic;
using MediatR;
using Nmro.IAM.Core.UseCases.PersistedGrants.Models;

namespace Nmro.IAM.Core.UseCases.PersistedGrants.Queries
{
    public class GetGrantQuery: IRequest<PersistedGrant>
    {
        public string Key {get;set;}
    }
}
