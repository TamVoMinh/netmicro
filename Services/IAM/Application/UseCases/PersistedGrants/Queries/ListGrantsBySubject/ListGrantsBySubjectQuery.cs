using System.Collections.Generic;
using MediatR;
using Nmro.IAM.Application.UseCases.PersistedGrants.Models;

namespace Nmro.IAM.Application.UseCases.PersistedGrants.Queries
{
    public class PersistedGrantsBySubjectQuery: IRequest<IEnumerable<PersistedGrant>>
    {
        public string SubjectId {get;set;}
    }
}
