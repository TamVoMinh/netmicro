using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Models;
using Nmro.IAM.Repository;
using Nmro.IAM.Repository.Entities;

namespace Nmro.IAM.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<List<ApiResourceModel>> GetAll()
        {
            List<ApiResource> resources = await _context.ApiResources.ToListAsync();
            var result = _mapper.Map<List<ApiResourceModel>>(resources);
            return result;
        }

        [HttpGet("api-resource")]
        public async Task<ApiResourceModel> GetApiResourceByName([FromQuery] string resourcename)
        {
            ApiResource resource = await _context.ApiResources.FirstOrDefaultAsync(x => x.Name.Equals(resourcename));
            var result = _mapper.Map<ApiResourceModel>(resource);
            return result;
        }

        [HttpPost("api-resource")]
        public async Task<List<ApiResourceModel>> GetApiResourceByScopeName([FromBody] IEnumerable<string> scopename)
        {
            List<ApiResource> resources = await _context.ApiResources.Where(x => x.Scopes.Any(s => scopename.Contains(s.Name))).ToListAsync();
            var result = _mapper.Map<List<ApiResourceModel>>(resources);
            return result;
        }

        [HttpPost("identity-resource")]
        public async Task<List<IdentityResourceModel>> GetIdentityResourceByScopeName([FromBody] IEnumerable<string> scopename)
        {
            List<IdentityResource> resources = await _context.IdentityResources.Where(x => scopename.Contains(x.Name)).ToListAsync();
            var result = _mapper.Map<List<IdentityResourceModel>>(resources);
            return result;
        }
    }
}
