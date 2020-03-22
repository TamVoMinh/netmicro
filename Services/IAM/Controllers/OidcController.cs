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
using Nmro.IAM.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Nmro.IAM.Controllers
{
    [Route("oidc")]
    [ApiController]
    public class OidcController : ControllerBase
    {
        private readonly ILogger<OidcController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        private readonly IPasswordValidator _passwordValidator;


        public OidcController(ILogger<OidcController> logger, IAMDbcontext context, IMapper mapper, IPasswordValidator passwordValidator)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
        }

        [HttpGet("resources")]
        [SwaggerOperation("Read all resources")]
        public async Task<ResourcesModel> GetAll()
        {
            ResourcesModel resources = new ResourcesModel();
            List<ApiResource> apiResources = await _context.ApiResources.Include(x => x.Scopes).Include(x => x.ApiSecrets).ToListAsync();
            List<IdentityResource> identityResources = await _context.IdentityResources.ToListAsync();

            resources.ApiResources = _mapper.Map<List<ApiResourceModel>>(apiResources);
            resources.IdentityResources = _mapper.Map<List<IdentityResourceModel>>(identityResources);
            return resources;
        }

        [HttpGet("resources/apis/{name}")]
        [SwaggerOperation("Read a api-resource by name")]
        public async Task<ApiResourceModel> GetApiResourceByName([FromRoute] string name)
        {
            ApiResource resource = await _context.ApiResources.FirstOrDefaultAsync(x => x.Name.Equals(name));
            ApiResourceModel result = _mapper.Map<ApiResourceModel>(resource);
            return result;
        }

        [HttpGet("resources/apis")]
        [SwaggerOperation("Query a set of api-resources by scopes")]
        public async Task<List<ApiResourceModel>> GetApiResourceByScopeName([FromQuery] List<string> scopes)
        {
            List<ApiResource> resources = await _context.ApiResources.Where(x => x.Scopes.Any(s => scopes.Contains(s.Name)))
                .Include(x => x.Scopes)
                .Include(x => x.ApiSecrets).ToListAsync();
            List<ApiResourceModel> result = _mapper.Map<List<ApiResourceModel>>(resources);
            return result;
        }

        [HttpGet("resources/identities")]
        [SwaggerOperation("Query a set of identity-resources by scopes")]
        public async Task<List<IdentityResourceModel>> GetIdentityResourceByScopeName([FromQuery] List<string> scopes)
        {
            List<IdentityResource> a = await _context.IdentityResources.ToListAsync();
            List<IdentityResource> resources = await _context.IdentityResources.Where(x => scopes.Contains(x.Name)).ToListAsync();
            List<IdentityResourceModel> result = _mapper.Map<List<IdentityResourceModel>>(resources);
            return result;
        }

        [HttpPost("users/validate")]
        [SwaggerOperation("Validate an user credential")]
        public async Task<ActionResult<UserProfileModel>> ValidateCredential([FromBody] CredentialModel credential)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(e => e.UserName.Equals(credential.Username));

            if (user != null)
            {
                var result = _passwordValidator.VerifyHashedPassword(user.Password, credential.Password, user.Salt);
                return (result == PasswordVerificationResult.Success)
                    ? _mapper.Map<UserProfileModel>(user)
                    : null;
            }

            return null;
        }


        [HttpGet("clients/{clientId}")]
        [SwaggerOperation("Read a client")]
        public async Task<ActionResult<ClientModel>> GetByClientId(string clientId)
        {
            var client = await _context.Clients
                .Where(e => e.ClientId.Equals(clientId) && !e.IsDeleted)
                .Include(e => e.ClientSecrets)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<ClientModel>(client);

            return result;
        }
    }
}
