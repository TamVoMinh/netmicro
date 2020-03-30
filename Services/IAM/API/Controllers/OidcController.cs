using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Nmro.IAM.Application.UseCases.Resources.Queries;
using Nmro.IAM.Application.UseCases.Users.Queries;
using Nmro.IAM.Application.UseCases.Clients.Queries;
using Nmro.IAM.API.Vms;

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
        public async Task<Resources> GetAll()
        {
            var all = await Mediator.Send(new ListAllResourcesQuery());
            return new Resources(all);
        }

        [HttpGet("resources/apis/{name}")]
        [SwaggerOperation("Read a api-resource by name")]
        public async Task<ApiResource> GetApiResourceByName([FromRoute] string name)
        {
           var apiResource =  await Mediator.Send(new GetApiResourceByNameQuery{ Name = name});
           return apiResource.ToViewModel();
        }

        [HttpGet("resources/apis")]
        [SwaggerOperation("Query a set of api-resources by scopes")]
        public async Task<IEnumerable<ApiResource>> GetApiResourceByScopeName([FromQuery] List<string> scopes)
        {
            var apiResources = await Mediator.Send(new ListApiResourcesByScopesQuery{Scopes = scopes});
            return apiResources.Select(x => x.ToViewModel());
        }

        [HttpGet("resources/identities")]
        [SwaggerOperation("Query a set of identity-resources by scopes")]
        public async Task<IEnumerable<IdentityResource>> GetIdentityResourceByScopeName([FromQuery] List<string> scopes)
        {
            var identityReources = await Mediator.Send(new ListIdentityResourcesByScopesQuery{Scopes = scopes});
            return identityReources.Select(x =>x.ToViewModel());
        }

        [HttpPost("users/validate")]
        [SwaggerOperation("Validate an user credential")]
        public async Task<IdentityUserModel> ValidateCredential([FromBody] CredentialModel credential)
        {
            var identityUser = await Mediator.Send(new ValidateCredentialQuery{ UserName = credential.UserName, Password = credential.Password });
            return identityUser.ToViewModel();
        }


        [HttpGet("clients/{clientId}")]
        [SwaggerOperation("Read a client")]
        public async Task<Client> GetByClientId(string clientId)
        {
            var client = await Mediator.Send(new GetClientByClientIdQuery{ ClientId = clientId});
            return client.ToViewModel();
        }
    }
}
