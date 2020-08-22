using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Infras.Storage.Configurations
{
    public class ClientScopeConfiguration : IEntityTypeConfiguration<ClientScope>
    {
        public void Configure(EntityTypeBuilder<ClientScope> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Scope).HasMaxLength(200).IsRequired();
        }
    }
}
