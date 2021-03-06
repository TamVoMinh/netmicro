using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.UseCases.PersistedGrants.Dtos;
using Nmro.Security.IAM.Core.UseCases.PersistedGrants.Dtos.Mappers;

namespace Nmro.Security.IAM.Core.UseCases.PersistedGrants.Queries
{
    public class GetGrantQueryHandler : IRequestHandler<GetGrantQuery, PersistedGrant>
    {
        private readonly IIAMDbcontext _context;
        private readonly ILogger<GetGrantQueryHandler> _logger;

        public GetGrantQueryHandler(IIAMDbcontext context, ILogger<GetGrantQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PersistedGrant> Handle(GetGrantQuery request, CancellationToken cancellationToken)
        {
            var persistedGrant = await _context.PersistedGrants.AsNoTracking().FirstOrDefaultAsync(x => x.Key == request.Key);
            var model = persistedGrant?.ToModel();

            _logger.LogDebug("{persistedGrantKey} found in database: {persistedGrantKeyFound}", request.Key, model != null);

            return model;
        }
    }
}
