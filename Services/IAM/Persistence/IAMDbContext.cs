using Microsoft.EntityFrameworkCore;
using Nmro.Blocks.Interfaces;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
using System;
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
        public IAMDbcontext(DbContextOptions options) : base(options) { }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //@TODO public auditing event from here
            foreach (var entry in ChangeTracker.Entries<Domain.Entities.AuditableEntity>())
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
