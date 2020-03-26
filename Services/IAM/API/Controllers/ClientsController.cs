using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Nmro.IAM.Repository.Entities;
using Nmro.IAM.Models;
using Nmro.IAM.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Nmro.IAM.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientsController : NmroControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IMapper _mapper;
        private readonly IAMDbcontext _context;

        public ClientsController(ILogger<ClientsController> logger, IAMDbcontext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation("Query a bunch of clients by name")]
        public async Task<ResponseResult<List<ClientModel>>> Filter([FromQuery] string clientName = "", int limit = 50, int offset = 0)
        {
            var query = string.IsNullOrEmpty(clientName) ? _context.Clients : _context.Clients.Where(x => x.ClientName.Contains(clientName) && !x.IsDeleted);

            int count = await query.CountAsync();

            query.Skip(offset).Take(limit);

            var clients = await query.ToListAsync();

            var responseClients = _mapper.Map<List<ClientModel>>(clients);

            return new ResponseResult<List<ClientModel>> { Total = count, Data = responseClients }; ;
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Read a client")]
        public async Task<ActionResult<ClientModel>> GetById(int id)
        {
            var client = await _context.Clients
                .Where(e => e.Id == id && !e.IsDeleted)
                .Include(e => e.ClientSecrets)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<ClientModel>(client);

            return result;
        }

        [HttpPost]
        [SwaggerOperation("Create new client")]
        public async Task<ActionResult<ClientModel>> Create([FromBody] ClientModel clientModel)
        {
            Client creatingClient = _mapper.Map<Client>(clientModel);

            creatingClient.CreatedDate = DateTime.UtcNow;

            await _context.Clients.AddAsync(creatingClient);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClientModel>(creatingClient);
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Update existing client")]
        public async Task<ActionResult<ClientModel>> Update([FromBody] ClientModel clientModel)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == clientModel.Id && !x.IsDeleted);
            if (client == null)
            {
                return NotFound("Client not exist.");
            }

            Client updatingClient = _mapper.Map<Client>(clientModel);
            updatingClient.UpdatedDate = DateTime.UtcNow;

            _context.Clients.Update(updatingClient);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClientModel>(updatingClient);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delele a client")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            client.IsDeleted = true;

            Client deleteClient = _mapper.Map<Client>(client);
            deleteClient.UpdatedDate = DateTime.UtcNow;

            _context.Clients.Update(deleteClient);
            await _context.SaveChangesAsync();

            return client.Id;
        }
    }
}
