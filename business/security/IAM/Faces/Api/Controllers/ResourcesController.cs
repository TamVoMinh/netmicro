using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Commands;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Queries;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Commands;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos;
using Nmro.Security.IAM.Core.UseCases.IdentityResources.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace Nmro.Security.IAM.Faces.API.Controllers
{
    [Route("resources")]
    [ApiExplorerSettings(GroupName="iams")]
    [ApiController]
    public class ResourcesController : NmroControllerBase
    {
        private readonly ILogger<ResourcesController> _logger;
        public ResourcesController(ILogger<ResourcesController> logger)
        {
            _logger = logger;
        }
        [HttpGet("apis")]
        [SwaggerOperation("Query a bunch of api-resources by name")]
        public async Task<PageApiResource> FilterApiResources([FromQuery] string name = "", int limit = 50, int offset = 0)
            => await Mediator.Send(new FilterApiResourcesByNameQuery{ Name = name, Limit = limit, Offset = offset });
        [HttpGet("apis/{id}")]
        [SwaggerOperation("Read a api-resources by name")]
        public async Task<ApiResource> GetApiResourceById(int id)
            => await Mediator.Send(new GetApiResourcesQuery{ ResourceId = id});

        [HttpPost("apis")]
        [SwaggerOperation("Create new api-resource")]
        public async Task<long> CreateApiResource([FromBody] ApiResource apiResource)
            => await Mediator.Send(new CreateApiResourceCommand { Model = apiResource });

        [HttpPut("apis/{id}")]
        [SwaggerOperation("Update a api-resource")]
        public async Task<long> UpdateApiResource([FromBody] ApiResource apiResource, int id)
            => await Mediator.Send(new UpdateApiResourceCommand{ Model = apiResource, ApiResourceId = id });

        [HttpDelete("apis/{id}")]
        [SwaggerOperation("Delete a api-resource")]
        public async Task<int> DeleteApiResource(int id)
            => await Mediator.Send(new DeleteApiResourceCommand{ApiResourceId = id});

        #region Resource Identity
        [HttpGet("identities")]
        [SwaggerOperation("Query a bunch of identity-resources by name")]
        public async Task<PageIdentityResource> FilterIdentityResources([FromQuery] string resourceName = "", int limit = 50, int offset = 0)
            => await Mediator.Send(new FilterIdentityResourcesByNameQuery{Name = resourceName, Limit = limit, Offset = offset});

        [HttpGet("identities/{id}")]
        [SwaggerOperation("Read an identity-resources")]
        public async Task<ActionResult<IdentityResource>> GetIdentityResourceById(int id)
            => await Mediator.Send(new GetIdentityResourceQuery{IdentityResourceId = id});

        [HttpPost("identities")]
        [SwaggerOperation("Create new identity-resource")]
        public async Task<int> CreateIdentityResource([FromBody] IdentityResource identityResource)
            => await Mediator.Send(new CreateIdentityResourceCommand{ Model = identityResource });

        [HttpPut("identities/{id}")]
        [SwaggerOperation("Update a identity-resource")]
        public async Task<int> UpdateIdentityResource([FromBody]  IdentityResource identityResource)
            => await Mediator.Send(new UpdateIdentityResourceCommand{Model = identityResource});

        [HttpDelete("identities/{id}")]
        [SwaggerOperation("Delete a identity-resource")]
        public async Task<int> DeleteIdentityResource(int id)
            => await Mediator.Send(new DeleteIdentityResourceCommand{ IdentityResourceId = id});

        #endregion
    }
}
