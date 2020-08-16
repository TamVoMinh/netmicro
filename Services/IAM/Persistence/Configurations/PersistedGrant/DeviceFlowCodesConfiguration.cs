using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Core.Entities;
namespace Nmro.IAM.Persistence.Configurations
{
    public class DeviceFlowCodesConfiguration : IEntityTypeConfiguration<DeviceFlowCodes>
    {
        public void Configure(EntityTypeBuilder<DeviceFlowCodes> builder)
        {
            builder.HasKey(x => new {x.UserCode});
            builder.Property(x => x.DeviceCode).HasMaxLength(200).IsRequired();
            builder.Property(x => x.UserCode).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SubjectId).HasMaxLength(200);
            builder.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.Expiration).IsRequired();
            builder.Property(x => x.Data).HasMaxLength(50000).IsRequired();
            builder.HasIndex(x => x.DeviceCode).IsUnique();
            builder.HasIndex(x => x.Expiration);
        }
    }
}
