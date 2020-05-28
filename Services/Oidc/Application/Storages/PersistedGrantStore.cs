using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nmro.Oidc.Infrastructure.IamClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.Oidc.Application.Storages
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<ClientStore> _logger;
        private readonly IRestOidc _restOidc;

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            var grants = await _restOidc.AllGrants(subjectId);
            return grants.Select(x => x.ToIds4Model());
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            var grant = await _restOidc.GetGrant(key);
            return grant.ToIds4Model();
        }

        public async Task RemoveAllAsync(string subjectId, string clientId)
        {
            await _restOidc.RemoveAllGrants(subjectId, clientId, string.Empty);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            await _restOidc.RemoveAllGrants(subjectId, clientId, type);
        }

        public async Task RemoveAsync(string key)
        {
            await _restOidc.RemoveGrant(key);
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            await _restOidc.StoreGrant(grant.ToModel());
        }
    }
}
