using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

using Nmro.IAM.Models;
using Nmro.IAM.Application;
using Nmro.IAM.Application.Users.Queries;
using Nmro.IAM.Application.Users.Commands;


namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : NmroControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation("Query a bunch of users by name")]
        public async Task<ResponseListResult<IdentityUserModel>> Filter([FromQuery] string email = "", int limit = 50, int offset = 0)
        {
            return await Mediator.Send(new ListUsersQuery{Email = email, Limit = limit, Offset = offset});
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Read an user")]
        public async Task<IdentityUserModel> GetById(long id)
        {
            return await Mediator.Send(new GetUsersQuery{UserId = id});
        }

        [HttpPost]
        [SwaggerOperation("Create new user")]
        public async Task<(long, DateTime)> Create([FromBody] UserCreatingModel user)
        {
            return await Mediator.Send(new UpsertUserCommand{
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email
            });
        }

        [HttpPut]
        [SwaggerOperation("Update a user")]
        public async Task<(long, DateTime)> Update([FromBody] UserUpdatingModel user)
        {
            return await Mediator.Send(new UpsertUserCommand{
                Id = user.Id,
                UpdatedDate = user.UpdatedDate,
                Password = user.Password,
                Email = user.Email
            });
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a user")]
        public async Task<(long, DateTime)> Delete(long id)
        {
            return await Mediator.Send(new DeleteUserCommand{ Id = id });
        }
    }
}
