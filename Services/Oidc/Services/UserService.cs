using Newtonsoft.Json;
using Nmro.Oidc.Infrastructure;
using Nmro.Oidc.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nmro.Oidc.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient iamClient;

        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

            iamClient = clientFactory.CreateClient("iam");
        }

        public async Task<User> ValidateCredentials(string username, string password)
        {
            var credentialContent = new StringContent(JsonConvert.SerializeObject(new
            {
                Username = username,
                Password = CryptoService.ComputeSha256Hash(password)
            }), System.Text.Encoding.UTF8, "application/json");

            var response = await iamClient.PostAsync(API.IdentityUser.ValidateCredentials(), credentialContent);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<User>(responseString);

            return result;
        }
    }
}
