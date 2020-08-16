using Microsoft.EntityFrameworkCore;
using Nmro.Common.Services;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.Entities;
using Nmro.Web.Services;
using System.Threading;
using System.Threading.Tasks;
namespace Nmro.IAM.Persistence
{
    public class IAMDbcontext : DbContext, IIAMDbcontext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        public DbSet<Client> Clients { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<ApiResource> ApiResources { get; set; }
        public DbSet<ApiScope> ApiScopes { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<PersistedGrant> PersistedGrants {get;set;}

        public IAMDbcontext(DbContextOptions<IAMDbcontext> options) : base(options) { }
         public IAMDbcontext(
            DbContextOptions<IAMDbcontext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //@TODO public auditing event from here
            foreach (var entry in ChangeTracker.Entries<Core.AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.Updated = _dateTime.Now;
                        entry.Entity.UpdatedBy = _currentUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.UserId;
                        entry.Entity.Updated = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAMDbcontext).Assembly);
        }
    }
}
