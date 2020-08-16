using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Core.Interfaces;

namespace Nmro.IAM.Core.UseCases.PersistedGrants.Commands
{
    public class RemoveAllGrantsCommandHandler : IRequestHandler<RemoveAllGrantsCommand, int>
    {

        private readonly IIAMDbcontext _context;
        private readonly ILogger<RemoveAllGrantsCommandHandler> _logger;
        public RemoveAllGrantsCommandHandler(IIAMDbcontext context, ILogger<RemoveAllGrantsCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Handle(RemoveAllGrantsCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Core.Entities.PersistedGrant, bool>> predicate = x =>
                request.Type == string.Empty
                    ? x.SubjectId == request.SubjectId && x.ClientId == request.ClientId
                    : x.SubjectId == request.SubjectId && x.ClientId == request.ClientId && x.Type == request.Type;

            var persistedGrants = await _context.PersistedGrants.Where(predicate).ToListAsync();

            _logger.LogDebug("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}", persistedGrants.Count, request.SubjectId, request.ClientId);

            _context.PersistedGrants.RemoveRange(persistedGrants);

            try
            {
               return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}: {error}", persistedGrants.Count, request.SubjectId, request.ClientId, ex.Message);
            }

            return 0;
        }
    }
}
