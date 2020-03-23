using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Repository.Entities;

namespace Nmro.IAM.Repository
{
    public class IAMDbcontext : DbContext
    {
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ApiResource> ApiResources { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<Scope> Scopes { get; set; }
        public DbSet<Secret> Secrets { get; set; }

        public IAMDbcontext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddIdentityUser();
            modelBuilder.AddClient();
            modelBuilder.AddApiResource();
            modelBuilder.AddIdentityResource();
            modelBuilder.AddScope();
            modelBuilder.AddSecret();
        }
    }
}
