using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Infras.Storage.Configurations
{
    public class ClientIdPRestrictionConfiguration : IEntityTypeConfiguration<ClientIdPRestriction>
    {
        public void Configure(EntityTypeBuilder<ClientIdPRestriction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Provider).HasMaxLength(200).IsRequired();
       }
    }
}
