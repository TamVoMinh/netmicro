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
    public class IdentityResourcesController : ControllerBase
    {
        private readonly ILogger<IdentityResourcesController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        public IdentityResourcesController(ILogger<IdentityResourcesController> logger, IAMDbcontext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseResult<List<IdentityResourceModel>>> FilterIdentityResources([FromQuery] string resourceName = "", int limit = 50, int offset = 0)
        {
            var query = string.IsNullOrEmpty(resourceName) ? _context.IdentityResources : _context.IdentityResources.Where(x => x.Name.Contains(resourceName) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(offset).Take(limit);

            var identityResources = await query.ToListAsync();

            var responseIdentityResources = _mapper.Map<List<IdentityResourceModel>>(identityResources);

            return new ResponseResult<List<IdentityResourceModel>> { Total = count, Data = responseIdentityResources }; ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityResourceModel>> GetIdentityResourceById(int id)
        {
            var resource = await _context.IdentityResources
                .Where(e => e.Id == id && !e.IsDeleted)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<IdentityResourceModel>(resource);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<IdentityResourceModel>> CreateIdentityResource([FromBody] IdentityResourceModel identityResourceModel)
        {
            IdentityResource creatingIdentityResource = _mapper.Map<IdentityResource>(identityResourceModel);

            creatingIdentityResource.CreatedDate = DateTime.UtcNow;

            await _context.IdentityResources.AddAsync(creatingIdentityResource);
            await _context.SaveChangesAsync();

            return _mapper.Map<IdentityResourceModel>(creatingIdentityResource);
        }

        [HttpPut]
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

        [HttpDelete("{id}")]
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
    }
}
