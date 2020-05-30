using MediatR;

namespace Nmro.IAM.Application.UseCases.PersistedGrants.Commands
{
    public class RemoveGrantCommand:IRequest<int>
    {
        public string TokenKey {get;set;}
    }
}
