using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nmro.Security.IAM.Core.Interfaces;

namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class CleanUpGrantsCommandHandler : IRequestHandler<CleanUpGrantsCommand, int>
    {

        private readonly IIAMDbcontext _context;
        private readonly ILogger<CleanUpGrantsCommandHandler> _logger;
        public CleanUpGrantsCommandHandler(IIAMDbcontext context, ILogger<CleanUpGrantsCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Handle(CleanUpGrantsCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Core.Entities.PersistedGrant, bool>> predicate = x => x.Expiration <= request.Now;

            var persistedGrants = await _context.PersistedGrants.Where(predicate).ToListAsync();

            _logger.LogDebug("removing expired {persistedGrantCount} persisted grants from database for being time {now}", persistedGrants.Count, request.Now);

            _context.PersistedGrants.RemoveRange(persistedGrants);

            try
            {
               return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("removing expired {persistedGrantCount} persisted grants from database for being time {now}, {error}", persistedGrants.Count, ex.Message);
            }

            return 0;
        }
    }
}
