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
        public async Task<ResourcesModel> GetAll()
        {
            ResourcesModel resources = new ResourcesModel();
            List<ApiResource> apiResources = await _context.ApiResources.ToListAsync();
            List<IdentityResource> identityResources = await _context.IdentityResources.ToListAsync();

            resources.ApiResources = _mapper.Map<List<ApiResourceModel>>(apiResources);
            resources.IdentityResources = _mapper.Map<List<IdentityResourceModel>>(identityResources);
            return resources;
        }

        [HttpGet("api-resource")]
        public async Task<ApiResourceModel> GetApiResourceByName([FromQuery] string resourcename)
        {
            ApiResource resource = await _context.ApiResources.FirstOrDefaultAsync(x => x.Name.Equals(resourcename));
            ApiResourceModel result = _mapper.Map<ApiResourceModel>(resource);
            return result;
        }

        [HttpGet("api-resource/scope")]
        public async Task<List<ApiResourceModel>> GetApiResourceByScopeName([FromQuery] List<string> scopename)
        {
            List<ApiResource> a = await _context.ApiResources.ToListAsync();
            List<ApiResource> resources = await _context.ApiResources.Where(x => x.Scopes.Any(s => scopename.Contains(s.Name))).ToListAsync();
            List<ApiResourceModel> result = _mapper.Map<List<ApiResourceModel>>(resources);
            return result;
        }

        [HttpGet("identity-resource")]
        public async Task<List<IdentityResourceModel>> GetIdentityResourceByScopeName([FromQuery] List<string> scopename)
        {
            List<IdentityResource> a = await _context.IdentityResources.ToListAsync();
            List<IdentityResource> resources = await _context.IdentityResources.Where(x => scopename.Contains(x.Name)).ToListAsync();
            List<IdentityResourceModel> result = _mapper.Map<List<IdentityResourceModel>>(resources);
            return result;
        }
    }
}
