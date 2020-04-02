using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Nmro.Common.Extentions;
using Nmro.Oidc.Infrastructure.IamClient.Models;
using Flurl.Http;
using Flurl;
using Microsoft.Extensions.Options;

namespace Nmro.Oidc.Infrastructure.IamClient
{
    public class RestOidc : IRestOidc
    {
        private readonly string _origin;
        private readonly IOptions<AppSettings> _appSetting;

        public RestOidc(IOptions<AppSettings> appsetting)
        {
            _appSetting = appsetting;
            _origin = appsetting.Value?.IdentityApiEndpoint ?? "http://iam-api/iam";
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

        public async Task<IdentityUser> ValidateCredential(string username, string password)
        {
            string apiEndpoint =  _origin.AppendPathSegments("oidc","users","validate");

            return await apiEndpoint
                .PostJsonAsync(new{UserName = username, Password = password.Sha256()})
                .ReceiveJson<IdentityUser>();
        }
    }
}
