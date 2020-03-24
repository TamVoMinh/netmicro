using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Nmro.IAM.Domain.Entities
{
    public class Client : EntityBase<int>
    {
        //
        // Summary:
        //     When requesting both an id token and access token, should the user claims always
        //     be added to the id token instead of requring the client to use the userinfo endpoint.
        //     Defaults to false.
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        //
        // Summary:
        //     Specifies the api scopes that the client is allowed to request. If empty, the
        //     client can't access any scope
        public ICollection<string> AllowedScopes { get; set; }
        //
        // Summary:
        //     Unique ID of the client
        public string ClientId { get; set; }
        //
        // Summary:
        //     Client secrets - only relevant for flows that require a secret
        public ICollection<Secret> ClientSecrets { get; set; }
        //
        // Summary:
        //     Client display name (used for logging and consent screen)
        public string ClientName { get; set; }
        //

        //
        // Summary:
        //     Specifies whether a consent screen is required (defaults to true)
        public bool RequireConsent { get; set; }
        //
        // Summary:
        //     Specifies the allowed grant types (legal combinations of AuthorizationCode, Implicit,
        //     Hybrid, ResourceOwner, ClientCredentials).
        public ICollection<string> AllowedGrantTypes { get; set; }
        //
        // Summary:
        //     Controls whether access tokens are transmitted via the browser for this client
        //     (defaults to false). This can prevent accidental leakage of access tokens when
        //     multiple response types are allowed.
        public bool AllowAccessTokensViaBrowser { get; set; }
        //
        // Summary:
        //     Specifies allowed URIs to return tokens or authorization codes to
        public ICollection<string> RedirectUris { get; set; }
        //
        // Summary:
        //     Specifies allowed URIs to redirect to after logout
        public ICollection<string> PostLogoutRedirectUris { get; set; }
        //
        // Summary:
        //     Gets or sets the allowed CORS origins for JavaScript clients.
        public ICollection<string> AllowedCorsOrigins { get; set; }
        //
        // Summary:
        //     Lifetime of access token in seconds (defaults to 3600 seconds / 1 hour)
        public int AccessTokenLifetime { get; set; }
        //
        // Summary:
        //     Lifetime of identity token in seconds (defaults to 300 seconds / 5 minutes)
        public int IdentityTokenLifetime { get; set; }
        //
        // Summary:
        //     If set to false, no client secret is needed to request tokens at the token endpoint
        //     (defaults to true)
        public bool RequireClientSecret { get; set; }
        //
        // Summary:
        //     Specifies whether a proof key is required for authorization code based token
        //     requests (defaults to false).
        public bool RequirePkce { get; set; }

        public bool IsDeleted { get; set; }
    }

    public static class ClientIdentityExtention
    {
        public static ModelBuilder AddClient(this ModelBuilder builder)
        {
            EntityTypeBuilder<Client> entityTable = builder.Entity<Client>();

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

            return builder;
        }
    }
}
