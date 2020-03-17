using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Caching.Distributed;
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
            string cachingKey = $"iam-find-client-{clientId}";
            string responseString = await _distributedCache.GetStringAsync(cachingKey);
            if(string.IsNullOrEmpty(responseString)){
                var getClientUri = API.Client.GetClientById(clientId);
                var response = await iamClient.GetAsync(getClientUri);

                responseString = await response.Content.ReadAsStringAsync();

                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _distributedCache.SetString(cachingKey, responseString , option);
            }

            var client = JsonConvert.DeserializeObject<Client>(responseString);
            return client;
        }
    }
}
