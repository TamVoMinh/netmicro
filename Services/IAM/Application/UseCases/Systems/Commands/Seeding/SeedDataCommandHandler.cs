using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.UseCases.Systems
{
    public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IPasswordProcessor _passwordProcessor;

        private readonly ILogger<DataSeeder> _logger;

        public SeedDataCommandHandler(IIAMDbcontext context, IPasswordProcessor passwordProcessor, ILogger<DataSeeder> logger)
        {
            _context = context;
            _passwordProcessor = passwordProcessor;
            _logger = logger;

        }

        public async Task<int> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new DataSeeder(_context, _passwordProcessor, _logger);

            await seeder.SeedAsync();

            return 1;
        }
    }
}