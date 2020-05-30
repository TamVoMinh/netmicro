using System.Collections.Generic;
using MediatR;
using Nmro.IAM.Application.UseCases.PersistedGrants.Models;

namespace Nmro.IAM.Application.UseCases.PersistedGrants.Queries
{
    public class GetGrantQuery: IRequest<PersistedGrant>
    {
        public string Key {get;set;}
    }
}
