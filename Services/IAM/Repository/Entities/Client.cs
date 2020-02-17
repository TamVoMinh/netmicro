using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nmro.IAM.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Repository.Entities
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
    }

    public static class ClientIdentityExtention
    {
        public static ModelBuilder AddClient(this ModelBuilder builder)
        {
            EntityTypeBuilder<Client> entityTable = builder.Entity<Client>();

            entityTable.HasKey(en => en.Id);
            entityTable.Property(en => en.Id).ValueGeneratedOnAdd();
            entityTable.HasIndex(en => en.ClientId).IsUnique();

            return builder;
        }
    }
}
