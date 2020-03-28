using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Persistence.Configurations
{
    public class IdentityResourceClaimConfiguration : IEntityTypeConfiguration<IdentityResourceClaim>
    {
        public void Configure(EntityTypeBuilder<IdentityResourceClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Type).HasMaxLength(200).IsRequired();
        }
    }
}
