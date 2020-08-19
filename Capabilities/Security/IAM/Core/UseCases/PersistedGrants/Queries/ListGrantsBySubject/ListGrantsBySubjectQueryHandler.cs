using System.Collections.Generic;
using System.Linq;
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
    public class ListGrantsBySubjectQueryHandler : IRequestHandler<PersistedGrantsBySubjectQuery, IEnumerable<PersistedGrant>>
    {
        private readonly IIAMDbcontext _context;
        private readonly ILogger<ListGrantsBySubjectQueryHandler> _logger;

        public ListGrantsBySubjectQueryHandler(IIAMDbcontext context, ILogger<ListGrantsBySubjectQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<PersistedGrant>> Handle(PersistedGrantsBySubjectQuery request, CancellationToken cancellationToken)
        {
            var persistedGrants = await _context.PersistedGrants.Where(x => x.SubjectId == request.SubjectId).AsNoTracking().ToListAsync();
            var model = persistedGrants.Select(x => x.ToModel());

            _logger.LogDebug("{persistedGrantCount} persisted grants found for {subjectId}", persistedGrants.Count, request.SubjectId);

            return model;
        }
    }
}
