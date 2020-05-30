using MediatR;
using Nmro.IAM.Application.UseCases.PersistedGrants.Models;

namespace Nmro.IAM.Application.UseCases.PersistedGrants.Commands
{
    public class StoreGrantCommand: IRequest<int>
    {
        public PersistedGrant Grant {get; set;}
    }
}
