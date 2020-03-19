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

namespace Nmro.IAM.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiResourcesController : ControllerBase
    {
        private readonly ILogger<ApiResourcesController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        public ApiResourcesController(ILogger<ApiResourcesController> logger, IAMDbcontext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseResult<List<ApiResourceModel>>> FilterApiResources([FromQuery] string resourceName = "", int limit = 50, int offset = 0)
        {
            var query = string.IsNullOrEmpty(resourceName) ? _context.ApiResources : _context.ApiResources.Where(x => x.Name.Contains(resourceName) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(offset).Take(limit);

            var apiResources = await query.ToListAsync();

            var responseApiResources = _mapper.Map<List<ApiResourceModel>>(apiResources);

            return new ResponseResult<List<ApiResourceModel>> { Total = count, Data = responseApiResources }; ;
        }

        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<ActionResult<ApiResourceModel>> CreateApiResource([FromBody] ApiResourceModel apiResourceModel)
        {
            ApiResource creatingApiResource = _mapper.Map<ApiResource>(apiResourceModel);

            creatingApiResource.CreatedDate = DateTime.UtcNow;

            await _context.ApiResources.AddAsync(creatingApiResource);
            await _context.SaveChangesAsync();

            return _mapper.Map<ApiResourceModel>(creatingApiResource);
        }

        [HttpPut]
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

        [HttpDelete("{id}")]
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
    }
}
