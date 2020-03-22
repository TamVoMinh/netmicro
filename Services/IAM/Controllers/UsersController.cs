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
using Nmro.IAM.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IAMDbcontext _context;

        public UsersController(ILogger<UsersController> logger, IAMDbcontext context, IMapper mapper, IPasswordValidator passwordValidator)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
        }

        [HttpGet]
        [SwaggerOperation("Query a bunch of users by name")]
        public async Task<ResponseResult<List<IdentityUserModel>>> Filter([FromQuery] string email = "", int limit = 50, int offset = 0)
        {
            var query = string.IsNullOrEmpty(email) ? _context.IdentityUsers.Where(x => !x.IsDeleted) : _context.IdentityUsers.Where(x => x.Email.Contains(email) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(offset).Take(limit);

            var users = await query.ToListAsync();

            var responseUsers = _mapper.Map<List<IdentityUserModel>>(users);

            return new ResponseResult<List<IdentityUserModel>> { Total = count , Data = responseUsers }; ;
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Read an user")]
        public async Task<ActionResult<IdentityUserModel>> GetById(long id)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (user == null)
            {
                return NotFound("User not exist.");
            }

            var result = _mapper.Map<IdentityUserModel>(user);

            return result;
        }

        [HttpPost]
        [SwaggerOperation("Create new user")]
        public async Task<ActionResult<IdentityUserModel>> Create([FromBody] RegistrationIdentityUserModel userIdentity)
        {
            IdentityUser creatingUser = _mapper.Map<IdentityUser>(userIdentity);

            creatingUser.CreatedDate = DateTime.UtcNow;
            creatingUser.Salt = _passwordValidator.GenerateSalt();
            creatingUser.Password = _passwordValidator.HashWithPbkdf2(creatingUser.Password, creatingUser.Salt);

            await _context.IdentityUsers.AddAsync(creatingUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<IdentityUserModel>(creatingUser);
        }

        [HttpPut]
        [SwaggerOperation("Update a user")]
        public async Task<ActionResult<IdentityUserModel>> Update([FromBody] RegistrationIdentityUserModel userIdentity)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == userIdentity.Id && !x.IsDeleted);
            if (user == null)
            {
                return NotFound("User not exist.");
            }

            IdentityUser updatingUser = _mapper.Map<IdentityUser>(userIdentity);
            updatingUser.UpdatedDate = DateTime.UtcNow;

            _context.IdentityUsers.Update(updatingUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<IdentityUserModel>(updatingUser);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a user")]
        public async Task<ActionResult<long>> Delete(long id)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            user.IsDeleted = true;

            IdentityUser deleteUser = _mapper.Map<IdentityUser>(user);
            deleteUser.UpdatedDate = DateTime.UtcNow;

            _context.IdentityUsers.Update(deleteUser);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        //[HttpGet("test")]
        //public ActionResult TestJsonBinding(TestModel model)
        //{
        //    return Ok(model);
        //}

    }
}
