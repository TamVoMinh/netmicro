using IdentityServer4.Models;
using IdentityServer4.Stores;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using Nmro.Oidc.Infrastructure.IamClient;

namespace Nmro.Oidc.Application.Storages
{
    public class ResourceStore : IResourceStore
    {
        private readonly IRestOidc _restOidc;
        private readonly ILogger<ResourceStore> _logger;

        public ResourceStore(IRestOidc restOidc, ILogger<ResourceStore> logger)
        {
            _restOidc = restOidc;
            _logger = logger;
        }

        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var apiResource = await _restOidc.GetAPiResource(name);
            return apiResource.ToIds4Model();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var apiResources = await _restOidc.FindApiResource(scopeNames);
            return apiResources.Select(x => x.ToIds4Model());
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var apiResources = await _restOidc.FindIdentityResource(scopeNames);
            return apiResources.Select(x => x.ToIds4Model());
        }

        public async Task<IdentityServer4.Models.Resources> GetAllResourcesAsync()
        {
            var allResources = await _restOidc.AllResources();
            return allResources.ToIds4Model();
        }
    }
}
