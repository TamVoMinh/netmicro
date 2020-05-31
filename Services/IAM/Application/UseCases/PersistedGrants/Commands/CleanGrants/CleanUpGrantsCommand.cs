using System;
using MediatR;

namespace Nmro.IAM.Application.UseCases.PersistedGrants.Commands
{
    public class CleanUpGrantsCommand:IRequest<int>
    {
        public DateTime Now {get;set;} = DateTime.UtcNow;
    }
}
