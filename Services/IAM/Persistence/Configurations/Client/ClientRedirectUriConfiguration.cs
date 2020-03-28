using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Persistence.Configurations
{
    public class ClientRedirectUriConfiguration : IEntityTypeConfiguration<ClientRedirectUri>
    {
        public void Configure(EntityTypeBuilder<ClientRedirectUri> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RedirectUri).HasMaxLength(2000).IsRequired();
        }
    }
}
