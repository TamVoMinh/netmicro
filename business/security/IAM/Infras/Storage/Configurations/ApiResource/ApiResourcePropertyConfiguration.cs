using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Infras.Storage.Configurations
{
    public class ApiResourcePropertyConfiguration : IEntityTypeConfiguration<ApiResourceProperty>
    {
        public void Configure(EntityTypeBuilder<ApiResourceProperty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Key).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(2000).IsRequired();
        }
    }
}
