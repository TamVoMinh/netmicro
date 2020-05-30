using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Application.UseCases.PersistedGrants.Models;
using Nmro.IAM.Application.UseCases.PersistedGrants.Queries;
using Swashbuckle.AspNetCore.Annotations;


namespace Nmro.IAM.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName="oidc")]
    [Route("oidc/subjects")]
    public class SubjectsController : NmroControllerBase
    {
        private readonly ILogger<SubjectsController> _logger;

        public SubjectsController(ILogger<SubjectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{subjectId}/grants")]
        [SwaggerOperation("List all grants of a Subject")]
        public async Task<IEnumerable<PersistedGrant>> ListAllGrantsOfSubject([FromRoute] string subjectId)
            => await Mediator.Send(new PersistedGrantsBySubjectQuery{ SubjectId = subjectId });
    }

}
