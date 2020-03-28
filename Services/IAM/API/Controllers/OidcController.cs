using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Nmro.IAM.Application.Resources.Models;
using Nmro.IAM.Application.Resources.Queries;
using Nmro.IAM.Application.Users.Queries;
using Nmro.IAM.Application.Users.Models;
using Nmro.IAM.Application.Clients.Queries;
using Nmro.IAM.Application.Clients.Models;

namespace Nmro.IAM.Controllers
{
    [Route("oidc")]
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
        public async Task<AllResources> GetAll()
        {
            return await Mediator.Send(new ListAllResourcesQuery());
        }

        [HttpGet("resources/apis/{name}")]
        [SwaggerOperation("Read a api-resource by name")]
        public async Task<ApiResource> GetApiResourceByName([FromRoute] string name)
        {
           return await Mediator.Send(new GetApiResourceByNameQuery{ Name = name});
        }

        [HttpGet("resources/apis")]
        [SwaggerOperation("Query a set of api-resources by scopes")]
        public async Task<IEnumerable<ApiResource>> GetApiResourceByScopeName([FromQuery] List<string> scopes)
        {
            return await Mediator.Send(new ListApiResourcesByScopesQuery{Scopes = scopes});
        }

        [HttpGet("resources/identities")]
        [SwaggerOperation("Query a set of identity-resources by scopes")]
        public async Task<IEnumerable<IdentityResource>> GetIdentityResourceByScopeName([FromQuery] List<string> scopes)
        {
            return await Mediator.Send(new ListIdentityResourcesByScopesQuery{Scopes = scopes});
        }

        [HttpPost("users/validate")]
        [SwaggerOperation("Validate an user credential")]
        public async Task<IdentityUserModel> ValidateCredential([FromBody] CredentialModel credential)
        {
            return await Mediator.Send(new ValidateCredentialQuery{ Credential = credential });
        }


        [HttpGet("clients/{clientId}")]
        [SwaggerOperation("Read a client")]
        public async Task<Client> GetByClientId(string clientId)
        {
            return await Mediator.Send(new GetClientByClientIdQuery{ ClientId = clientId});
        }
    }
}
