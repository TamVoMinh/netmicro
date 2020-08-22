using MediatR;
using Nmro.Security.IAM.Core.UseCases.PersistedGrants.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class StoreGrantCommand: IRequest<int>
    {
        public PersistedGrant Grant {get; set;}
    }
}
