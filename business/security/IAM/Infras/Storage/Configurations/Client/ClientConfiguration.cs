using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Infras.Storage.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(en => en.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ProtocolType).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ClientName).HasMaxLength(200);
            builder.Property(x => x.ClientUri).HasMaxLength(2000);
            builder.Property(x => x.LogoUri).HasMaxLength(2000);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.FrontChannelLogoutUri).HasMaxLength(2000);
            builder.Property(x => x.BackChannelLogoutUri).HasMaxLength(2000);
            builder.Property(x => x.ClientClaimsPrefix).HasMaxLength(200);
            builder.Property(x => x.PairWiseSubjectSalt).HasMaxLength(200);
            builder.Property(x => x.UserCodeType).HasMaxLength(100);
            builder.Property(x => x.AllowedIdentityTokenSigningAlgorithms).HasMaxLength(100);
            builder.HasIndex(x => x.ClientId).IsUnique();
            builder.HasMany(x => x.AllowedGrantTypes).WithOne(x => x.Client).HasForeignKey(x=>x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.RedirectUris).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.PostLogoutRedirectUris).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.AllowedScopes).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ClientSecrets).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Claims).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.IdentityProviderRestrictions).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.AllowedCorsOrigins).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Properties).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
