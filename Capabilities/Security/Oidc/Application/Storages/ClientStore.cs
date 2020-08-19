using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nmro.Oidc.Infrastructure.IamClient;
using System.Threading.Tasks;

namespace Nmro.Oidc.Application.Storages
{
    public class ClientStore : IClientStore
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<ClientStore> _logger;
        private readonly IRestOidc _restOidc;

        public ClientStore(IRestOidc restOidc, IDistributedCache distributedCache, ILogger<ClientStore> logger)
        {
            _restOidc = restOidc;
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            string cachingKey = $"find-oidc-client-{clientId}";
            string cachingString = await _distributedCache.GetStringAsync(cachingKey);

            if(string.IsNullOrEmpty(cachingString)){

                var oidcClient = await _restOidc.GetClient(clientId);

                var result = oidcClient.ToIds4Model();

                cachingString = JsonConvert.SerializeObject(result);

                return result;
             }

             return JsonConvert.DeserializeObject<Client>(cachingString);

        }
    }
}
