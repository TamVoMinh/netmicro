using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Nmro.IAM.Repository.Entities;
using Nmro.IAM.Models;
using Nmro.IAM.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityUserController : ControllerBase
    {
        private readonly ILogger<IdentityUserController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        public IdentityUserController(ILogger<IdentityUserController> logger, IAMDbcontext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<IdentityUserModel>> GettAll()
        {
            var user = await _context.IdentityUsers.Where(x => !x.IsDelete).ToListAsync();
            var result = _mapper.Map<List<IdentityUserModel>>(user);

            return result;
        }

        [HttpGet("id")]
        public async Task<ActionResult<IdentityUserModel>> GetById(long id)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if(user == null)
            {
                return NotFound("User not exist.");
            }

            var result = _mapper.Map<IdentityUserModel>(user);

            return result;
        }

        [HttpGet]
        public async Task<ActionResult<UserProfileModel>> GetByUsername([FromQuery] string username)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(e => e.UserName.Equals(username) && !e.IsDelete);
            var result = _mapper.Map<UserProfileModel>(user);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] IdentityUserModel userIdentityModel)
        {
            IdentityUser creatingUser = _mapper.Map<IdentityUser>(userIdentityModel);
            creatingUser.CreatedDate = DateTime.UtcNow;

            await _context.IdentityUsers.AddAsync(creatingUser);
            await _context.SaveChangesAsync();

            return creatingUser.Id;
        }

        [HttpPut]
        public async Task<ActionResult<long>> Update([FromBody] IdentityUserModel userIdentityModel)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == userIdentityModel.Id && !x.IsDelete);
            if(user == null)
            {
                return NotFound("User not exist.");
            }

            IdentityUser updatingUser = _mapper.Map<IdentityUser>(userIdentityModel);
            updatingUser.UpdatedDate = DateTime.UtcNow;

            _context.IdentityUsers.Update(updatingUser);
            await _context.SaveChangesAsync();

            return updatingUser.Id;
        }

        [HttpPost("credential-validation")]
        public async Task<ActionResult<bool>> ValidateCredential([FromBody] CredentialModel credential)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(e => e.UserName.Equals(credential.Username));

            return user != null && user.Password.Equals(credential.Password);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<long>> Delete(long id)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);

            user.IsDelete = true;

            IdentityUser deleteUser = _mapper.Map<IdentityUser>(user);
            deleteUser.UpdatedDate = DateTime.UtcNow;

            _context.IdentityUsers.Update(deleteUser);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        [HttpGet("test")]
        public ActionResult TestJsonBinding(TestModel model)
        {
            return Ok(model);
        }

    }
}
