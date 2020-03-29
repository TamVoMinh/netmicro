using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

using Nmro.IAM.Application;
using Nmro.IAM.Application.UseCases.Resources.Commands;
using Nmro.IAM.Application.UseCases.Resources.Queries;
using Nmro.IAM.Application.UseCases.Resources.Models;
namespace Nmro.IAM.API.Controllers
{
    [Route("resources")]
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
        public async Task<ListResult<ApiResource>> FilterApiResources([FromQuery] string name = "", int limit = 50, int offset = 0)
        {
            return await Mediator.Send(new FilterApiResourcesByNameQuery{ Name = name, Limit = limit, Offset = offset });
        }
        [HttpGet("apis/{id}")]
        [SwaggerOperation("Read a api-resources by name")]
        public async Task<ApiResource> GetApiResourceById(int id)
        {
            return await Mediator.Send(new GetApiResourcesQuery{ ResourceId = id});
        }
        [HttpPost("apis")]
        [SwaggerOperation("Create new api-resource")]
        public async Task<long> CreateApiResource([FromBody] ApiResource apiResource)
        {
           return await Mediator.Send(new CreateApiResourceCommand { Model = apiResource });
        }
        [HttpPut("apis/{id}")]
        [SwaggerOperation("Update a api-resource")]
        public async Task<long> UpdateApiResource([FromBody] ApiResource apiResource, int id)
        {
            return await Mediator.Send(new UpdateApiResourceCommand{ Model = apiResource, ApiResourceId = id });
        }
        [HttpDelete("apis/{id}")]
        [SwaggerOperation("Delete a api-resource")]
        public async Task<int> DeleteApiResource(int id)
        {
           return await Mediator.Send(new DeleteApiResourceCommand{ApiResourceId = id});
        }
        #region Resource Identity
        [HttpGet("identities")]
        [SwaggerOperation("Query a bunch of identity-resources by name")]
        public async Task<ListResult<IdentityResource>> FilterIdentityResources([FromQuery] string resourceName = "", int limit = 50, int offset = 0)
        {
            return await Mediator.Send(new FilterIdentityResourcesByNameQuery{Name = resourceName, Limit = limit, Offset = offset});
        }
        [HttpGet("identities/{id}")]
        [SwaggerOperation("Read an identity-resources")]
        public async Task<ActionResult<IdentityResource>> GetIdentityResourceById(int id)
        {
           return await Mediator.Send(new GetIdentityResourceQuery{IdentityResourceId = id});
        }
        [HttpPost("identities")]
        [SwaggerOperation("Create new identity-resource")]
        public async Task<int> CreateIdentityResource([FromBody] IdentityResource identityResource)
        {
           return await Mediator.Send(new CreateIdentityResourceCommand{ Model = identityResource });
        }
        [HttpPut("identities/{id}")]
        [SwaggerOperation("Update a identity-resource")]
        public async Task<int> UpdateIdentityResource([FromBody]  IdentityResource identityResource)
        {
            return await Mediator.Send(new UpdateIdentityResourceCommand{Model = identityResource});
        }
        [HttpDelete("identities/{id}")]
        [SwaggerOperation("Delete a identity-resource")]
        public async Task<int> DeleteIdentityResource(int id)
        {
            return await Mediator.Send(new DeleteIdentityResourceCommand{ IdentityResourceId = id});
        }
        #endregion
    }
}
