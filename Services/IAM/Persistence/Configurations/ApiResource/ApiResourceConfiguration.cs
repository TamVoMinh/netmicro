using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Persistence.Configurations
{
    public class ApiResourceConfiguration : IEntityTypeConfiguration<ApiResource>
    {
        public void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            builder.HasKey(en => en.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DisplayName).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.AllowedAccessTokenSigningAlgorithms).HasMaxLength(100);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.Secrets).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Scopes).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.UserClaims).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Properties).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
