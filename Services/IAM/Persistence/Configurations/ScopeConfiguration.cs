using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Persistence.Configurations
{
    public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> entityTable)
        {
            entityTable.HasKey(en => en.Id);
            entityTable.Property(en => en.Id).ValueGeneratedOnAdd();
            entityTable.HasOne(s => s.ApiResource)
                .WithMany(c => c.Scopes)
                .HasForeignKey(s => s.ApiResourceId);
        }
    }
}
