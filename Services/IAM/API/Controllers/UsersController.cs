using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Nmro.IAM.Core.UseCases.Users.Queries;
using Nmro.IAM.Core.UseCases.Users.Commands;
using Nmro.IAM.Core.UseCases.Users.Models;

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
            =>  await Mediator.Send(new ListIdentityUsersQuery{Email = email, Limit = limit, Offset = offset});


        [HttpGet("{id}")]
        [SwaggerOperation("Read an user")]
        public async Task<IdentityUser> GetById(long id)
            => await Mediator.Send(new GetIdentityUsersQuery{UserId = id});

        [HttpPost]
        [SwaggerOperation("Create new user")]
        public async Task<int> Create([FromBody] CreatingUserModel user)
            => await Mediator.Send(new CreateIdentityUserCommand{Model = user});


        [HttpPut]
        [SwaggerOperation("Update a user")]
        public async Task<int> Update([FromBody] UpdatingUserModel user)
            =>  await Mediator.Send(new UpdateIdentityUserCommand{Model = user});


        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a user")]
        public async Task<int> Delete(int id)
            => await Mediator.Send(new DeleteIdentityUserCommand{ Id = id });

    }
}
