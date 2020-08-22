using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Infras.Storage.Configurations
{
    public class ClientCorsOriginConfiguration : IEntityTypeConfiguration<ClientCorsOrigin>
    {
        public void Configure(EntityTypeBuilder<ClientCorsOrigin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Origin).HasMaxLength(150).IsRequired();
        }
    }
}
