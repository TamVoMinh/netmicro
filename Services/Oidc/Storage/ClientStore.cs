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

        public ClientStore(IHttpClientFactory clientFactory, IDistributedCache distributedCache)
        {
            _clientFactory = clientFactory;
            _distributedCache = distributedCache;
            iamClient = clientFactory.CreateClient("iam");
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var getClientUri = API.Client.GetClientById(clientId);

            var response = await iamClient.GetAsync(getClientUri);

            var responseString = await response.Content.ReadAsStringAsync();

            var client = JsonConvert.DeserializeObject<Client>(responseString);

            var tokenLifeTime = _distributedCache.GetString(nameof(client.AccessTokenLifetime));

            if(string.IsNullOrEmpty(tokenLifeTime))
            {
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(client.AccessTokenLifetime));
                _distributedCache.SetString(tokenLifeTime, client.AccessTokenLifetime.ToString(), option);
            }

            return client;
        }
    }
}
