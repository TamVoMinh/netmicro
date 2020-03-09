using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Nmro.IAM.Repository.Entities;
using Nmro.IAM.Models;
using Nmro.IAM.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        public ClientController(ILogger<ClientController> logger, IAMDbcontext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] ClientModel model)
        {
            Client creatingClient = _mapper.Map<Client>(model);

            await _context.Clients.AddAsync(creatingClient);
            await _context.SaveChangesAsync();

            return creatingClient.Id;
        }

        [HttpGet]
        public async Task<ActionResult<ClientModel>> GetByClientId(string clientId)
        {
            var client = await _context.Clients
                .Where(e => e.ClientId.Equals(clientId))
                .Include(e => e.ClientSecrets)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<ClientModel>(client);

            _logger.LogInformation("[GET] Client {@result}", result);

            return result;
        }
    }
}
