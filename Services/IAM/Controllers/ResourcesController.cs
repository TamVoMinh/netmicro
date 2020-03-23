using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Models;
using Nmro.IAM.Repository;
using Nmro.IAM.Repository.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Nmro.IAM.Controllers
{
    [Route("resources")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly ILogger<ResourcesController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        public ResourcesController(ILogger<ResourcesController> logger, IAMDbcontext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("apis")]
        [SwaggerOperation("Query a bunch of api-resources by name")]
        public async Task<ResponseResult<List<ApiResourceModel>>> FilterApiResources([FromQuery] string resourceName = "", int limit = 50, int offset = 0)
        {
            var query = string.IsNullOrEmpty(resourceName) ? _context.ApiResources : _context.ApiResources.Where(x => x.Name.Contains(resourceName) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(offset).Take(limit);

            var apiResources = await query.ToListAsync();

            var responseApiResources = _mapper.Map<List<ApiResourceModel>>(apiResources);

            return new ResponseResult<List<ApiResourceModel>> { Total = count, Data = responseApiResources }; ;
        }

        [HttpGet("apis/{id}")]
        [SwaggerOperation("Read a api-resources by name")]
        public async Task<ActionResult<ApiResourceModel>> GetApiResourceById(int id)
        {
            var resource = await _context.ApiResources
                .Where(e => e.Id == id && !e.IsDeleted)
                .Include(e => e.ApiSecrets)
                .Include(e => e.Scopes)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<ApiResourceModel>(resource);

            return result;
        }

        [HttpPost("apis")]
        [SwaggerOperation("Create new api-resource")]
        public async Task<ActionResult<ApiResourceModel>> CreateApiResource([FromBody] ApiResourceModel apiResourceModel)
        {
            ApiResource creatingApiResource = _mapper.Map<ApiResource>(apiResourceModel);

            creatingApiResource.CreatedDate = DateTime.UtcNow;

            await _context.ApiResources.AddAsync(creatingApiResource);
            await _context.SaveChangesAsync();

            return _mapper.Map<ApiResourceModel>(creatingApiResource);
        }

        [HttpPut("apis/{id}")]
        [SwaggerOperation("Update a api-resource")]
        public async Task<ActionResult<ApiResourceModel>> UpdateApiResource([FromBody] ApiResourceModel apiResourceModel)
        {
            var resource = await _context.ApiResources.FirstOrDefaultAsync(x => x.Id == apiResourceModel.Id && !x.IsDeleted);
            if (resource == null)
            {
                return NotFound("Api Resource not exist.");
            }

            ApiResource updatingApiResource = _mapper.Map<ApiResource>(apiResourceModel);
            updatingApiResource.UpdatedDate = DateTime.UtcNow;

            _context.ApiResources.Update(updatingApiResource);
            await _context.SaveChangesAsync();

            return _mapper.Map<ApiResourceModel>(updatingApiResource);
        }

        [HttpDelete("apis/{id}")]
        [SwaggerOperation("Delete a api-resource")]
        public async Task<ActionResult<int>> DeleteApiResource(int id)
        {
            var apiResource = await _context.ApiResources.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            apiResource.IsDeleted = true;

            ApiResource deleteApiResource = _mapper.Map<ApiResource>(apiResource);
            deleteApiResource.UpdatedDate = DateTime.UtcNow;

            _context.ApiResources.Update(deleteApiResource);
            await _context.SaveChangesAsync();

            return apiResource.Id;
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
