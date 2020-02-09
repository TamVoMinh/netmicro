using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Reposistory.Entities;
namespace Nmro.IAM.Reposistory
{
    public class IAMDbcontext: DbContext{
        public DbSet<IdentityUser> IdentityUsers {get;set;}

        public IAMDbcontext(DbContextOptions options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.AddIdentityUser();
        }
    }
}
