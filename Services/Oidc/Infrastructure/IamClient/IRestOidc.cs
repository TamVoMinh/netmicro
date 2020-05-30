using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nmro.Oidc.Infrastructure.IamClient
{
    public interface IRestOidc
    {
        Task<Models.IdentityUser> ValidateCredential(string username, string password);

        Task<Models.Client> GetClient(string clientId);

        Task<IEnumerable<Models.IdentityResource>> FindIdentityResource(IEnumerable<string> scopes);

        Task<Models.ApiResource> GetAPiResource(string name);

        Task<IEnumerable<Models.ApiResource>> FindApiResource(IEnumerable<string> scopes);

        Task<Models.AllResources> AllResources();

        Task<IEnumerable<Models.PersistedGrant>> AllGrants(string subjectId);

        Task<Models.PersistedGrant> GetGrant(string key);

        Task<int> RemoveAllGrants(string subjectId, string clientId, string type);

        Task<int> StoreGrant(Models.PersistedGrant grant);

        Task<int> RemoveGrant(string key);
    }
}
