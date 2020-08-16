using System.Collections.Generic;
using MediatR;
using Nmro.IAM.Core.UseCases.PersistedGrants.Models;

namespace Nmro.IAM.Core.UseCases.PersistedGrants.Queries
{
    public class PersistedGrantsBySubjectQuery: IRequest<IEnumerable<PersistedGrant>>
    {
        public string SubjectId {get;set;}
    }
}
