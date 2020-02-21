using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Nmro.Oidc.Infrastructure;
using Newtonsoft.Json;

namespace Nmro.Oidc.Storage
{
    public class ResourceStore: IResourceStore
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient iamClient;

        public ResourceStore(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            iamClient = clientFactory.CreateClient("iam");
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
            List<ApiResource> apiResources = new List<ApiResource>();

            foreach (string scopeName in scopeNames)
            {
                var uri = API.Resource.GetApiResourceByScope(scopeName);

                var response = await iamClient.GetAsync(uri);

                var responseString = await response.Content.ReadAsStringAsync();

                var client = JsonConvert.DeserializeObject<ApiResource>(responseString);
                apiResources.Add(client);
            }
            return apiResources;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            List<IdentityResource> apiResources = new List<IdentityResource>();

            foreach (string scopeName in scopeNames)
            {
                var uri = API.Resource.GetApiResourceByScope(scopeName);

                var response = await iamClient.GetAsync(uri);

                var responseString = await response.Content.ReadAsStringAsync();

                var client = JsonConvert.DeserializeObject<IdentityResource>(responseString);
                apiResources.Add(client);
            }
            return apiResources;
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
