using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.UseCases.Systems
{
    public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand>
    {
        private readonly IIAMDbcontext _context;
        private readonly IPasswordProcessor _passwordProcessor;

        private readonly ILogger _logger;

        SeedDataCommandHandler(IIAMDbcontext context, IPasswordProcessor passwordProcessor, ILogger<SeedDataCommandHandler> logger)
        {
            _context = context;
            _passwordProcessor = passwordProcessor;
            _logger = logger;
        }

        public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new DataSeeder(_context, _passwordProcessor, _logger);

            await seeder.SeedAsync();

            return Unit.Value;
        }
    }
}
