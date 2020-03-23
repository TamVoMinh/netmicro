using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nmro.IAM.Repository.Entities
{
    public class IdentityUser : EntityBase<long>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public byte[] Salt { get; set; }

        public DateTime LastSuccessfulLogin { get; set; }

        public DateTime LastFailedLogin { get; set; }

        public bool IsDeleted { get; set; }
    }

    public static class UserIdentityExtention
    {
        public static ModelBuilder AddIdentityUser(this ModelBuilder builder)
        {
            EntityTypeBuilder<IdentityUser> entityTable = builder.Entity<IdentityUser>();

            entityTable.HasKey(en => en.Id);
            entityTable.Property(en => en.Id).ValueGeneratedOnAdd();
            return builder;
        }
    }

}
