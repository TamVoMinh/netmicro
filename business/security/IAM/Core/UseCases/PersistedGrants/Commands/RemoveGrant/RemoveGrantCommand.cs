using MediatR;

namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class RemoveGrantCommand:IRequest<int>
    {
        public string TokenKey {get;set;}
    }
}
