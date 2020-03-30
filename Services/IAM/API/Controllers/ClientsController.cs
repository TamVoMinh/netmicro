using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Nmro.IAM.Application.UseCases.Clients.Queries;
using Nmro.IAM.Application.UseCases.Clients.Models;
using Nmro.IAM.Application;
using Nmro.IAM.Application.UseCases.Clients.Commands;

namespace Nmro.IAM.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName="iams")]
    [Route("clients")]
    public class ClientsController : NmroControllerBase
    {
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation("Query a bunch of clients by name")]
        public async Task<PageClient> Filter([FromQuery] string clientName = "", int limit = 50, int offset = 0)
        {
            return await Mediator.Send(new FilterClientsByNameQuery{ Name = clientName, Limit = limit, Offset = offset});
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Read a client")]
        public async Task<Client> GetById(int id)
        {
            return await Mediator.Send(new GetClientQuery{Id = id});
        }

        [HttpPost]
        [SwaggerOperation("Create new client")]
        public async Task<int> Create([FromBody] CreateClientModel createModel)
        {
           return await Mediator.Send(new CreateClientCommand{Model = createModel});
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Update existing client")]
        public async Task<int> Update([FromBody] UpdateClientModel updateModel)
        {
            return await Mediator.Send(new UpdateClientCommand{Model = updateModel});
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delele a client")]
        public async Task<int> Delete(int id)
        {
           return await Mediator.Send(new DeleteClientCommand{Id = id});
        }
    }
}
