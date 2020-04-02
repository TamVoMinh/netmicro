using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Nmro.IAM.Application.UseCases.Resources.Queries;
using Nmro.IAM.Application.UseCases.Resources.Models;
using Nmro.IAM.Application.UseCases.Users.Queries;
using Nmro.IAM.Application.UseCases.Clients.Queries;
using Nmro.IAM.Application.UseCases.Users.Models;
using Nmro.IAM.Application.UseCases.Clients.Models;

namespace Nmro.IAM.API.Controllers
{
    [Route("oidc")]
    [ApiExplorerSettings(GroupName="oidc")]
    [ApiController]
    public class OidcController : NmroControllerBase
    {
        private readonly ILogger<OidcController> _logger;

        public OidcController(ILogger<OidcController> logger)
        {
            _logger = logger;
        }

        [HttpGet("resources")]
        [SwaggerOperation("Read all resources")]
        public async Task<AllResources> ListAllResources()
        {
            return await Mediator.Send(new ListAllResourcesQuery());
        }

        [HttpGet("resources/apis/{name}")]
        [SwaggerOperation("Read a api-resource by name")]
        public async Task<ApiResource> GetApiResourceByName([FromRoute] string name)
        {
           return  await Mediator.Send(new GetApiResourceByNameQuery{ Name = name});
        }

        [HttpGet("resources/apis")]
        [SwaggerOperation("Query a set of api-resources by scopes")]
        public async Task<IEnumerable<ApiResource>> ListApiResourceByScopeName([FromQuery] List<string> scopes)
        {
            return await Mediator.Send(new ListApiResourcesByScopesQuery{Scopes = scopes});
        }

        [HttpGet("resources/identities")]
        [SwaggerOperation("Query a set of identity-resources by scopes")]
        public async Task<IEnumerable<IdentityResource>> ListIdentityResourceByScopeName([FromQuery] List<string> scopes)
        {
            return await Mediator.Send(new ListIdentityResourcesByScopesQuery{Scopes = scopes});
        }

        [HttpPost("users/validate")]
        [SwaggerOperation("Validate an user credential")]
        public async Task<IdentityUser> ValidateCredential([FromBody] CredentialModel credential)
        {
            return await Mediator.Send(new ValidateCredentialQuery{ Username = credential.UserName, Password = credential.Password });
        }


        [HttpGet("clients/{clientId}")]
        [SwaggerOperation("Read a client")]
        public async Task<Client> GetOidcClientById(string clientId)
        {
            return await Mediator.Send(new GetClientByClientIdQuery{ ClientId = clientId});
        }
    }
}
