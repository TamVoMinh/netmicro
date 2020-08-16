using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Core.Entities;
using System;
namespace Nmro.IAM.Persistence.Configurations
{
    public class ApiResourceSecretConfiguration : IEntityTypeConfiguration<ApiResourceSecret>
    {
        public void Configure(EntityTypeBuilder<ApiResourceSecret> builder)
        {
                builder.HasKey(x => x.Id);
                builder.Property(en => en.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Description).HasMaxLength(1000);
                builder.Property(x => x.Value).HasMaxLength(4000).IsRequired();
                builder.Property(x => x.Type).HasMaxLength(250).IsRequired();
        }
    }
}
