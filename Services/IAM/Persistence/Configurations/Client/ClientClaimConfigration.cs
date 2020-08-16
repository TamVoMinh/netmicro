using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Core.Entities;
namespace Nmro.IAM.Persistence.Configurations
{
    public class ClientClaimConfigration : IEntityTypeConfiguration<ClientClaim>
    {
        public void Configure(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Type).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(250).IsRequired();
        }
    }
}
