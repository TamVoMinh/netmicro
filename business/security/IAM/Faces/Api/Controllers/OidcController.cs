using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Nmro.Security.IAM.Core.UseCases.Clients.Queries;
using Nmro.Security.IAM.Core.UseCases.Users.Dtos;
using Nmro.Security.IAM.Core.UseCases.Clients.Dtos;
using Nmro.Security.IAM.Core.UseCases.Aggregations.Dtos;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Queries;
using Nmro.Security.IAM.Core.UseCases.Aggregations.Queries;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Queries;
using Nmro.Security.IAM.Core.UseCases.Users.Queries;

namespace Nmro.Security.IAM.Faces.API.Controllers
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
            => await Mediator.Send(new ListAllResourcesQuery());

        [HttpGet("resources/apis/{name}")]
        [SwaggerOperation("Read a api-resource by name")]
        public async Task<ApiResource> GetApiResourceByName([FromRoute] string name)
            => await Mediator.Send(new GetApiResourceByNameQuery{ Name = name});

        [HttpGet("resources/apis")]
        [SwaggerOperation("Query a set of api-resources by scopes")]
        public async Task<IEnumerable<ApiResource>> ListApiResourceByScopeName([FromQuery] List<string> scopes)
            => await Mediator.Send(new ListApiResourcesByScopesQuery{Scopes = scopes});

        [HttpGet("resources/identities")]
        [SwaggerOperation("Query a set of identity-resources by scopes")]
        public async Task<IEnumerable<IdentityResource>> ListIdentityResourceByScopeName([FromQuery] List<string> scopes)
            => await Mediator.Send(new ListIdentityResourcesByScopesQuery{Scopes = scopes});

        [HttpPost("users/validate")]
        [SwaggerOperation("Validate an user credential")]
        public async Task<IdentityUser> ValidateCredential([FromBody] CredentialModel credential)
            => await Mediator.Send(new ValidateCredentialQuery{ Username = credential.UserName, Password = credential.Password });

        [HttpGet("clients/{clientId}")]
        [SwaggerOperation("Read a client")]
        public async Task<Client> GetOidcClientById(string clientId)
            => await Mediator.Send(new GetClientByClientIdQuery{ ClientId = clientId});

    }
}
