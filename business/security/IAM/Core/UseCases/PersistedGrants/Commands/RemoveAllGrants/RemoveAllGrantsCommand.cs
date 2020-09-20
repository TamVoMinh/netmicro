using MediatR;

namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class RemoveAllGrantsCommand:IRequest<int>
    {
        public string SubjectId {get;set;}
        public string ClientId {get;set;}
        public string Type {get;set;} = string.Empty;

    }
}
