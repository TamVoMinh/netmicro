using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Core.Entities;
namespace Nmro.IAM.Persistence.Configurations
{
    public class PersistedGrantConfiguration : IEntityTypeConfiguration<PersistedGrant>
    {
        public void Configure(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Key).HasMaxLength(200).ValueGeneratedNever();
            builder.Property(x => x.Type).HasMaxLength(50).IsRequired();
            builder.Property(x => x.SubjectId).HasMaxLength(200);
            builder.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.Data).HasMaxLength(50000).IsRequired();
            builder.HasIndex(x => new { x.SubjectId, x.ClientId, x.Type });
            builder.HasIndex(x => x.Expiration);
        }
    }
}
