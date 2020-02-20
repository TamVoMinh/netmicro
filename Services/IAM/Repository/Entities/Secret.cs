using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Repository.Entities
{
    public class Secret : EntityBase<long>
    {
        //
        // Summary:
        //     Gets or sets the description.
        public string Description { get; set; }
        //
        // Summary:
        //     Gets or sets the value.
        public string Value { get; set; }
        //
        // Summary:
        //     Gets or sets the expiration.
        public DateTime? Expiration { get; set; }
        //
        // Summary:
        //     Gets or sets the type of the client secret.
        public string Type { get; set; }

        public int ClientId { get; set; }

        public int ApiResourceId { get; set; }

        public Client Client { get; set; }

        public ApiResource ApiResource { get; set; }

    }

    public static class SecretExtention
    {
        public static ModelBuilder AddSecret(this ModelBuilder builder)
        {
            EntityTypeBuilder<Secret> entityTable = builder.Entity<Secret>();

            entityTable.HasKey(en => en.Id);
            entityTable.Property(en => en.Id).ValueGeneratedOnAdd();
            entityTable
                .HasOne(s => s.Client)
                .WithMany(c => c.ClientSecrets)
                .HasForeignKey(s => s.ClientId);
            entityTable
                .HasOne(s => s.ApiResource)
                .WithMany(c => c.ApiSecrets)
                .HasForeignKey(s => s.ApiResourceId);

            return builder;
        }
    }
}
