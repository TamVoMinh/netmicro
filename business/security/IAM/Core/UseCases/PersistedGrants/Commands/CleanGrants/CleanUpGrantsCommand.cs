using System;
using MediatR;

namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class CleanUpGrantsCommand:IRequest<int>
    {
        public DateTime Now {get;set;} = DateTime.UtcNow;
    }
}
