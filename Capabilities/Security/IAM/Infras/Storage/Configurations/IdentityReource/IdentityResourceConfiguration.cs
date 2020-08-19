using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Infras.Storage.Configurations
{
    public class IdentityResourceConfiguration : IEntityTypeConfiguration<IdentityResource>
    {
        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DisplayName).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.UserClaims).WithOne(x => x.IdentityResource).HasForeignKey(x => x.IdentityResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Properties).WithOne(x => x.IdentityResource).HasForeignKey(x => x.IdentityResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
