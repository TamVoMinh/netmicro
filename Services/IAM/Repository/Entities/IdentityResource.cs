using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Nmro.IAM.Repository.Entities
{
    public class IdentityResource : Resource
    {
        //
        // Summary:
        //     Specifies whether the user can de-select the scope on the consent screen (if
        //     the consent screen wants to implement such a feature). Defaults to false.
        public bool Required { get; set; }
        //
        // Summary:
        //     Specifies whether the consent screen will emphasize this scope (if the consent
        //     screen wants to implement such a feature). Use this setting for sensitive or
        //     important scopes. Defaults to false.
        public bool Emphasize { get; set; }
        //
        // Summary:
        //     Specifies whether this scope is shown in the discovery document. Defaults to
        //     true.
        public bool ShowInDiscoveryDocument { get; set; }
        public bool IsDeleted { get; set; }
    }

    public static class IdentityResourceExtention
    {
        public static ModelBuilder AddIdentityResource(this ModelBuilder builder)
        {
            EntityTypeBuilder<IdentityResource> entityTable = builder.Entity<IdentityResource>();

            entityTable.HasKey(en => en.Id);
            entityTable.Property(en => en.Id).ValueGeneratedOnAdd();
            entityTable.Property(e => e.UserClaims)
                         .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            return builder;
        }
    }
}
