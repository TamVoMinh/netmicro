using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application.UseCases.PersistedGrants.Commands
{
    public class RemoveGrantCommandHandler : IRequestHandler<RemoveGrantCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly ILogger<RemoveGrantCommandHandler> _logger;
        public RemoveGrantCommandHandler(IIAMDbcontext context, ILogger<RemoveGrantCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Handle(RemoveGrantCommand request, CancellationToken cancellationToken)
        {
             var persistedGrant = await _context.PersistedGrants.FirstOrDefaultAsync(x => x.Key == request.TokenKey);
            if (persistedGrant!= null)
            {
                _logger.LogDebug("removing {persistedGrantKey} persisted grant from database", request.TokenKey);

                _context.PersistedGrants.Remove(persistedGrant);

                try
                {
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    _logger.LogInformation("exception removing {persistedGrantKey} persisted grant from database: {error}", request.TokenKey, ex.Message);
                }
            }
            else
            {
                _logger.LogDebug("no {persistedGrantKey} persisted grant found in database", request.TokenKey);
            }

            return 0;
        }
    }
}
