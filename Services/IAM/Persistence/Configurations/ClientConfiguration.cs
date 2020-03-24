using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entityTable)
        {
            entityTable.HasKey(en => en.Id);

            entityTable.Property(en => en.Id).ValueGeneratedOnAdd();
            entityTable.Property(e => e.AllowedScopes)
                         .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            entityTable.Property(e => e.AllowedGrantTypes)
                         .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            entityTable.Property(e => e.RedirectUris)
                         .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            entityTable.Property(e => e.PostLogoutRedirectUris)
                         .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            entityTable.Property(e => e.AllowedCorsOrigins)
                         .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            entityTable.HasIndex(en => en.ClientId).IsUnique();
        }
    }
}
