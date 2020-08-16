using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Core.Interfaces;
using System.Threading;

namespace Nmro.IAM.Core.UseCases.Systems
{
    public class DataSeeder
    {
        private readonly IPasswordProcessor _passwordProcessor;

        private readonly IIAMDbcontext _context;

        private readonly ILogger<DataSeeder> _logger;

        public DataSeeder(IIAMDbcontext context, IPasswordProcessor passwordProcessor, ILogger<DataSeeder> logger)
        {
            _context = context;
            _passwordProcessor = passwordProcessor;
            _logger = logger;
        }

        public async Task SeedAsync()
        {

            _logger.LogInformation("Start seeding...");

            if (!_context.IdentityUsers.Any())
            {
                await _context.IdentityUsers.AddRangeAsync(SeedUsers.List(_passwordProcessor));
                await _context.SaveChangesAsync(CancellationToken.None);
            }

            if (!_context.Clients.Any())
            {
                await _context.Clients.AddRangeAsync(SeedClients.List());
                await _context.SaveChangesAsync(CancellationToken.None);
            }

            if (!_context.IdentityResources.Any())
            {
                await _context.IdentityResources.AddRangeAsync(SeedIdentityResources.List());
                await _context.SaveChangesAsync(CancellationToken.None);
            }

            if (!_context.ApiResources.Any())
            {
                await _context.ApiResources.AddRangeAsync(SeedApiResources.List());
                await _context.SaveChangesAsync(CancellationToken.None);
            }


            _logger.LogInformation("End seeding.");
        }
    }
}
