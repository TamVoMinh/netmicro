using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Nmro.IAM.Application.UseCases.Users.Queries;
using Nmro.IAM.Application.UseCases.Users.Commands;
using Nmro.IAM.Application.UseCases.Users.Models;

namespace Nmro.IAM.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName="iams")]
    [Route("users")]
    public class UsersController : NmroControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation("Query a bunch of users by name")]
        public async Task<PageIdentityUserModel> Filter([FromQuery] string email = "", int limit = 50, int offset = 0)
        {
            return await Mediator.Send(new ListUsersQuery{Email = email, Limit = limit, Offset = offset});
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Read an user")]
        public async Task<IdentityUser> GetById(long id)
        {
            return await Mediator.Send(new GetUsersQuery{UserId = id});
        }

        [HttpPost]
        [SwaggerOperation("Create new user")]
        public async Task<int> Create([FromBody] CreatingUserModel user)
        {
            return await Mediator.Send(new CreateUserCommand{Model = user});
        }

        [HttpPut]
        [SwaggerOperation("Update a user")]
        public async Task<int> Update([FromBody] UpdatingUserModel user)
        {
            return await Mediator.Send(new UpdateUserCommand{Model = user});
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a user")]
        public async Task<int> Delete(int id)
        {
            return await Mediator.Send(new DeleteUserCommand{ Id = id });
        }
    }
}
