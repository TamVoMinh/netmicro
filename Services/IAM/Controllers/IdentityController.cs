using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Nmro.IAM.Reposistory.Entities;
using Nmro.IAM.Models;
using Nmro.IAM.Reposistory;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Serilog;

namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        public IdentityController(ILogger<IdentityController> logger, IAMDbcontext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] IdentityUserModel userIdentityModel)
        {
            IdentityUser creatingUser = _mapper.Map<IdentityUser>(userIdentityModel);
            await _context.IdentityUsers.AddAsync(creatingUser);
            await _context.SaveChangesAsync();

            return creatingUser.Id;
        }

        [HttpGet]
        public async Task<ActionResult<UserProfileModel>> GetByUsername(string username)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(e => e.UserName.Equals(username));
            var result = _mapper.Map<UserProfileModel>(user);

            return result;
        }

        [HttpPost("credential-validation")]
        public async Task<ActionResult<bool>> ValidateCredential([FromBody] UserCredentialModel credential)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(e => e.UserName.Equals(credential.Username));

            return user != null && user.Password.Equals(credential.Password);
        }
    }
}
