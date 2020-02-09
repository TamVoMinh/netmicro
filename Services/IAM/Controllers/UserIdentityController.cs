using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Nmro.IAM.Reposistory.Entities;
using Nmro.IAM.Models;
using Nmro.IAM.Reposistory;

namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserIdentityController : ControllerBase
    {
        private readonly ILogger<UserIdentityController> _logger;
        private readonly IAMDbcontext _context;
        private readonly IMapper _mapper;


        public UserIdentityController(ILogger<UserIdentityController> logger, IAMDbcontext context,IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateUserIdentity([FromBody] IdentityUserModel userIdentityModel)
        {
            IdentityUser creatingUser = _mapper.Map<IdentityUser>(userIdentityModel);
            await _context.IdentityUsers.AddAsync(creatingUser);
            var result  =  await _context.SaveChangesAsync();

            return creatingUser.Id;
        }

    }
}
