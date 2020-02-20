using Newtonsoft.Json;
using Nmro.Oidc.Infrastructure;
using Nmro.Oidc.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<User> FindByUsername(string username)
        {
            var getUserUri = API.IdentityUser.GetUserByUsername(username);

            var response = await iamClient.GetAsync(getUserUri);

            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<User>(responseString);

            return user;
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            var credentialContent = new StringContent(JsonConvert.SerializeObject(new
            {
                Username = username,
                Password = password
            }), System.Text.Encoding.UTF8, "application/json");

            var response = await iamClient.PostAsync(API.IdentityUser.ValidateCredentials(), credentialContent);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<bool>(responseString);

            return result;
        }
    }
}
