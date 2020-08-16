using MediatR;
using Nmro.IAM.Core.UseCases.PersistedGrants.Dtos;

namespace Nmro.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class StoreGrantCommand: IRequest<int>
    {
        public PersistedGrant Grant {get; set;}
    }
}
