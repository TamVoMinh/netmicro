using MediatR;

namespace Nmro.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class RemoveGrantCommand:IRequest<int>
    {
        public string TokenKey {get;set;}
    }
}
