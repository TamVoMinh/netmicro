using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nmro.IAM.Repository.Entities
{
    public class Scope : EntityBase<long>
    {
        //
        // Summary:
        //     Name of the scope. This is the value a client will use to request the scope.
        public string Name { get; set; }

        public int ApiResourceId { get; set; }

        public ApiResource ApiResource { get; set; }
    }

    public static class ScopeExtention
    {
        public static ModelBuilder AddScope(this ModelBuilder builder)
        {
            EntityTypeBuilder<Scope> entityTable = builder.Entity<Scope>();

            entityTable.HasKey(en => en.Id);
            entityTable.Property(en => en.Id).ValueGeneratedOnAdd();
            entityTable
                .HasOne(s => s.ApiResource)
                .WithMany(c => c.Scopes)
                .HasForeignKey(s => s.ApiResourceId);

            return builder;
        }
    }
}
