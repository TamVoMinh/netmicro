using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Nmro.Shared.Extentions;
using Nmro.Oidc.Infrastructure.IamClient.Models;
using Flurl.Http;
using Flurl;
using Microsoft.Extensions.Options;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Nmro.Oidc.Infrastructure.IamClient
{
    public class RestOidc : IRestOidc
    {
        private readonly string _origin;
        private readonly IOptions<AppSettings> _appSetting;

        private readonly ILogger<RestOidc> _logger;

        public RestOidc(IOptions<AppSettings> appsetting, ILogger<RestOidc> logger)
        {
            _appSetting = appsetting;
            _origin = appsetting.Value?.IdentityApiEndpoint ?? "http://iam-api/iam";
            _logger = logger;
        }

        public async Task<IEnumerable<Models.PersistedGrant>> AllGrants(string subjectId)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc", "subjects", subjectId, "grants");

            return await apiEndpoint.GetAsync().ReceiveJson<IEnumerable<Models.PersistedGrant>>();
        }

        public async Task<Models.AllResources> AllResources()
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","resources");

            return await apiEndpoint.GetAsync().ReceiveJson<Models.AllResources>();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResource(IEnumerable<string> scopes)
        {
            string apiEndpoint =  _origin
                .AppendPathSegments("oidc","resources","apis")
                .SetQueryParam("scopes", scopes.ToArray());

            return await apiEndpoint.GetAsync().ReceiveJson<IEnumerable<ApiResource>>();
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResource(IEnumerable<string> scopes)
        {
            string apiEndpoint =  _origin
                .AppendPathSegments("oidc","resources","identities")
                .SetQueryParam("scopes", scopes.ToArray());

            return await apiEndpoint.GetAsync().ReceiveJson<IEnumerable<IdentityResource>>();
        }

        public async Task<ApiResource> GetAPiResource(string name)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","resources","apis", name);

            return await apiEndpoint.GetAsync().ReceiveJson<ApiResource>();
        }

        public async Task<Client> GetClient(string clientId)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","clients", clientId);

            return await apiEndpoint.GetAsync().ReceiveJson<Client>();
        }

        public async Task<PersistedGrant> GetGrant(string key)
        {

            _logger.LogTrace("URL {0}", WebUtility.UrlEncode(key));

            string apiEndpoint =  _origin.AppendPathSegments("oidc","grants", WebUtility.UrlEncode(key));

            return await apiEndpoint.GetAsync().ReceiveJson<PersistedGrant>();
        }

        public async Task<int> RemoveAllGrants(string subjectId, string clientId, string type)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","grants").SetQueryParams(new {
                subjectId = subjectId,
                clientId = clientId,
                type = type
            });

            return await apiEndpoint.DeleteAsync().ReceiveJson<int>();
        }

        public async Task<int> RemoveGrant(string key)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","grants", key);
            return await apiEndpoint.DeleteAsync().ReceiveJson<int>();
        }

        public async Task<int> StoreGrant(PersistedGrant grant)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","grants");
            return await apiEndpoint.PostJsonAsync(grant).ReceiveJson<int>();
        }

        public async Task<IdentityUser> ValidateCredential(string username, string password)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","users","validate");

            return await apiEndpoint
                .PostJsonAsync(new{UserName = username, Password = password.Sha256()})
                .ReceiveJson<IdentityUser>();
        }
    }
}
