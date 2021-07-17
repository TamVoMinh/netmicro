using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nmro.Security.IAM.Core.UseCases.PersistedGrants.Commands;
using Nmro.Security.IAM.Core.UseCases.PersistedGrants.Dtos;
using Nmro.Security.IAM.Core.UseCases.PersistedGrants.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace Nmro.Security.IAM.Faces.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName="oidc")]
    [Route("oidc/grants")]
    public class GrantsController : NmroControllerBase
    {
        private readonly ILogger<GrantsController> _logger;

        public GrantsController(ILogger<GrantsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation("Store a grant")]
        public async Task<int> StoreGrant([FromBody] PersistedGrant grant)
            => await Mediator.Send(new StoreGrantCommand{ Grant = grant });

        [HttpGet("{key}")]
        [SwaggerOperation("Get a grant")]
        public async Task<PersistedGrant> GetGrant([FromRoute] string key)
            => await Mediator.Send(new GetGrantQuery{ Key = WebUtility.UrlDecode(key) });

        [HttpDelete("{key}")]
        [SwaggerOperation("Delete a grant")]
        public async Task<int> RemoveGrant([FromRoute] string key)
            => await Mediator.Send(new RemoveGrantCommand{ TokenKey = WebUtility.UrlDecode(key) });

        [HttpDelete]
        [SwaggerOperation("Delete All related Grants")]
        public async Task<int> DeleteGrants([FromQuery] string subjectId, string clientId, string type)
            => await Mediator.Send(new RemoveAllGrantsCommand{ SubjectId = subjectId, ClientId = clientId, Type = type});
    }
}
