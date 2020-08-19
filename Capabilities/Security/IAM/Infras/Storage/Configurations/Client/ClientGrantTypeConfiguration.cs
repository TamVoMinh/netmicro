using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Infras.Storage.Configurations
{
    public class ClientGrantTypeConfiguration : IEntityTypeConfiguration<ClientGrantType>
    {
        public void Configure(EntityTypeBuilder<ClientGrantType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.GrantType).HasMaxLength(250).IsRequired();
        }
    }
}
