using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Application;
using Nmro.IAM.Application.Resources;
using Nmro.IAM.Application.Resources.Commands;
using Nmro.IAM.Application.Resources.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace Nmro.IAM.Controllers
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
        public async Task<ResponseListResult<ApiResourceModel>> FilterApiResources([FromQuery] string name = "", int limit = 50, int offset = 0)
        {
            return await Mediator.Send(new ListApiResourcesQuery{ Name = name, Limit = limit, Offset = offset });

        }

        [HttpGet("apis/{id}")]
        [SwaggerOperation("Read a api-resources by name")]
        public async Task<ApiResourceModel> GetApiResourceById(int id)
        {
            return await Mediator.Send(new GetApiResourcesQuery{ ResourceId = id});
        }

        [HttpPost("apis")]
        [SwaggerOperation("Create new api-resource")]
        public async Task<long> CreateApiResource([FromBody] CreateResourceModel createResourceModel)
        {
           return await Mediator.Send(new CreateResourceCommand { Model = createResourceModel });
        }

        [HttpPut("apis/{id}")]
        [SwaggerOperation("Update a api-resource")]
        public async Task<long> UpdateApiResource([FromBody] UpdateResourceModel updateResourceModel)
        {
            return await Mediator.Send(new UpdateResourceCommand{ Model = updateResourceModel });
        }

        [HttpDelete("apis/{id}")]
        [SwaggerOperation("Delete a api-resource")]
        public async Task<int> DeleteApiResource(int id)
        {
           return await Mediator.Send(new DeleteResourceCommand{Id = id});
        }

        #region Resource Identity
        [HttpGet("identities")]
        [SwaggerOperation("Query a bunch of identity-resources by name")]
        public async Task<ResponseResult<List<IdentityResourceModel>>> FilterIdentityResources([FromQuery] string resourceName = "", int limit = 50, int offset = 0)
        {
            var query = string.IsNullOrEmpty(resourceName) ? _context.IdentityResources : _context.IdentityResources.Where(x => x.Name.Contains(resourceName) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(offset).Take(limit);

            var identityResources = await query.ToListAsync();

            var responseIdentityResources = _mapper.Map<List<IdentityResourceModel>>(identityResources);

            return new ResponseResult<List<IdentityResourceModel>> { Total = count, Data = responseIdentityResources }; ;
        }

        [HttpGet("identities/{id}")]
        [SwaggerOperation("Read an identity-resources")]
        public async Task<ActionResult<IdentityResourceModel>> GetIdentityResourceById(int id)
        {
            var resource = await _context.IdentityResources
                .Where(e => e.Id == id && !e.IsDeleted)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<IdentityResourceModel>(resource);

            return result;
        }

        [HttpPost("identities")]
        [SwaggerOperation("Create new identity-resource")]
        public async Task<ActionResult<IdentityResourceModel>> CreateIdentityResource([FromBody] IdentityResourceModel identityResourceModel)
        {
            IdentityResource creatingIdentityResource = _mapper.Map<IdentityResource>(identityResourceModel);

            creatingIdentityResource.CreatedDate = DateTime.UtcNow;

            await _context.IdentityResources.AddAsync(creatingIdentityResource);
            await _context.SaveChangesAsync();

            return _mapper.Map<IdentityResourceModel>(creatingIdentityResource);
        }

        [HttpPut("identities/{id}")]
        [SwaggerOperation("Update a identity-resource")]
        public async Task<ActionResult<IdentityResourceModel>> UpdateIdentityResource([FromBody] IdentityResourceModel identityResourceModel)
        {
            var resource = await _context.IdentityResources.FirstOrDefaultAsync(x => x.Id == identityResourceModel.Id && !x.IsDeleted);
            if (resource == null)
            {
                return NotFound("Api Resource not exist.");
            }

            IdentityResource updatingIdentityResource = _mapper.Map<IdentityResource>(identityResourceModel);
            updatingIdentityResource.UpdatedDate = DateTime.UtcNow;

            _context.IdentityResources.Update(updatingIdentityResource);
            await _context.SaveChangesAsync();

            return _mapper.Map<IdentityResourceModel>(updatingIdentityResource);
        }

        [HttpDelete("identities/{id}")]
        [SwaggerOperation("Delete a identity-resource")]
        public async Task<ActionResult<int>> DeleteIdentityResource(int id)
        {
            var identityResource = await _context.IdentityResources.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            identityResource.IsDeleted = true;

            IdentityResource deleteIdentityResource = _mapper.Map<IdentityResource>(identityResource);
            deleteIdentityResource.UpdatedDate = DateTime.UtcNow;

            _context.IdentityResources.Update(deleteIdentityResource);
            await _context.SaveChangesAsync();

            return identityResource.Id;
        }
        #endregion
    }
}
