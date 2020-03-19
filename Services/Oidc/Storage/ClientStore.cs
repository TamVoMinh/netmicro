using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nmro.Oidc.Infrastructure;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nmro.Oidc.Storage
{
    public class ClientStore : IClientStore
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient iamClient;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<ClientStore> _logger;

        public ClientStore(IHttpClientFactory clientFactory, IDistributedCache distributedCache, ILogger<ClientStore> logger)
        {
            _clientFactory = clientFactory;
            _distributedCache = distributedCache;
            _logger = logger;
            iamClient = clientFactory.CreateClient("iam");
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            string cachingKey = $"iam-find-client-{clientId}";
            string responseString = await _distributedCache.GetStringAsync(cachingKey);
            _logger.LogWarning("vo day");
            if(string.IsNullOrEmpty(responseString)){
                var getClientUri = API.Client.GetClientByClientId(clientId);
                _logger.LogWarning("vo day uriiii {0}",getClientUri);
                var response = await iamClient.GetAsync(getClientUri);
                _logger.LogWarning("vo day responsessss {0}",response);
                responseString = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("vo day responseStringgg {0}", responseString);
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _distributedCache.SetString(cachingKey, responseString , option);
            }

            var client = JsonConvert.DeserializeObject<Client>(responseString);
            return client;
        }
    }
}
