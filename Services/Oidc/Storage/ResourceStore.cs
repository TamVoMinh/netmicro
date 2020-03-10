using IdentityServer4.Models;
using IdentityServer4.Stores;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Nmro.Oidc.Infrastructure;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Nmro.Oidc.Storage
{
    public class ResourceStore : IResourceStore
    {
        private readonly HttpClient iamClient;
        private readonly ILogger<ResourceStore> _logger;

        public ResourceStore(IHttpClientFactory clientFactory, ILogger<ResourceStore> logger)
        {
            iamClient = clientFactory.CreateClient("iam");
            _logger = logger;
        }

        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var uri = API.Resource.GetApiResourceByName(name);

            var response = await iamClient.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var client = JsonConvert.DeserializeObject<ApiResource>(responseString);

            return client;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var queryString = $"scopes={string.Join("&scopes=", scopeNames)}";

            var uri = API.Resource.GetApiResourceByScope(queryString);

            var response = await iamClient.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            List<ApiResource> apiResources = JsonConvert.DeserializeObject<List<ApiResource>>(responseString);

            return apiResources;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var queryString = $"scopes={string.Join("&scopes=", scopeNames)}";
            var uri = API.Resource.GetIdentityResourceByScope(queryString);

            var response = await iamClient.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var identityResources = JsonConvert.DeserializeObject<IEnumerable<IdentityResource>>(responseString);

            return identityResources;
        }

        public async Task<IdentityServer4.Models.Resources> GetAllResourcesAsync()
        {
            var uri = API.Resource.GetAllResources();

            var response = await iamClient.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var client = JsonConvert.DeserializeObject<IdentityServer4.Models.Resources>(responseString);

            return client;
        }
    }
}
