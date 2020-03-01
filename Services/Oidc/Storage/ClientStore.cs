using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nmro.Oidc.Infrastructure;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nmro.Oidc.Storage
{
    public class ClientStore : IClientStore
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient iamClient;
        private readonly ILogger<ClientStore> _logger;


        public ClientStore(IHttpClientFactory clientFactory, ILogger<ClientStore> logger)
        {
            _clientFactory = clientFactory;

            iamClient = clientFactory.CreateClient("iam");

            _logger = logger;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var getClientUri = API.Client.GetClientById(clientId);

            var response = await iamClient.GetAsync(getClientUri);

            var responseString = await response.Content.ReadAsStringAsync();

            _logger.LogInformation(" RESPONSE_CLIENT: {responseString}", responseString);

            var client = JsonConvert.DeserializeObject<Client>(responseString);

            _logger.LogInformation("Parsed Model:  {@Client}", client);

            return client;
        }
    }
}
