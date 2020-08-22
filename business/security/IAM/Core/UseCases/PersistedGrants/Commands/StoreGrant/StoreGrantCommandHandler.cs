using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.PersistedGrants.Dtos.Mappers;

namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class StoreGrantCommandHandler : IRequestHandler<StoreGrantCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly ILogger<StoreGrantCommandHandler> _logger;
        public StoreGrantCommandHandler(IIAMDbcontext context, ILogger<StoreGrantCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(StoreGrantCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.PersistedGrants.SingleOrDefaultAsync(x => x.Key == request.Grant.Key);
            if (existing == null)
            {
                _logger.LogDebug("{persistedGrantKey} not found in database", request.Grant.Key);

                var persistedGrant = request.Grant.ToEntity();
                _context.PersistedGrants.Add(persistedGrant);
            }
            else
            {
                _logger.LogDebug("{persistedGrantKey} found in database", request.Grant.Key);

                request.Grant.UpdateEntity(existing);
            }

            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning("exception updating {persistedGrantKey} persisted grant in database: {error}", request.Grant.Key, ex.Message);
                return 0;
            }
        }
    }

}
