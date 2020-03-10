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

namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityUserController : ControllerBase
    {
        private readonly ILogger<IdentityUserController> _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IAMDbcontext _context;

        public IdentityUserController(ILogger<IdentityUserController> logger, IAMDbcontext context, IMapper mapper, IPasswordValidator passwordValidator)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
        }

        [HttpGet]
        public async Task<List<IdentityUserModel>> Filter([FromQuery] string email = "", int limit = 50, int offset = 0)
        {
            var query = string.IsNullOrEmpty(email) ? _context.IdentityUsers.Where(x => !x.IsDelete) : _context.IdentityUsers.Where(x => x.Email.Contains(email) && !x.IsDelete);
            query.Skip(offset).Take(limit);

            var user = await query.ToListAsync();
            var result = _mapper.Map<List<IdentityUserModel>>(user);

            return result;
        }

        [HttpGet("id")]
        public async Task<ActionResult<IdentityUserModel>> GetById(long id)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (user == null)
            {
                return NotFound("User not exist.");
            }

            var result = _mapper.Map<IdentityUserModel>(user);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] IdentityUserModel userIdentityModel)
        {
            IdentityUser creatingUser = _mapper.Map<IdentityUser>(userIdentityModel);

            creatingUser.CreatedDate = DateTime.UtcNow;
            creatingUser.Salt = _passwordValidator.GenerateSalt();
            creatingUser.Password = _passwordValidator.HashWithPbkdf2(creatingUser.Password, creatingUser.Salt);

            await _context.IdentityUsers.AddAsync(creatingUser);
            await _context.SaveChangesAsync();

            return creatingUser.Id;
        }

        [HttpPut]
        public async Task<ActionResult<long>> Update([FromBody] IdentityUserModel userIdentityModel)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Id == userIdentityModel.Id && !x.IsDelete);
            if (user == null)
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
        public async Task<ActionResult<IdentityUserModel>> ValidateCredential([FromBody] CredentialModel credential)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(e => e.UserName.Equals(credential.Username));

            if (user != null)
            {
                var result = _passwordValidator.VerifyHashedPassword(user.Password, credential.Password, user.Salt);
                return (result == PasswordVerificationResult.Success)
                    ? _mapper.Map<IdentityUserModel>(user)
                    : null;
            }

            return null;
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
