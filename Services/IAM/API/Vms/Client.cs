using System.Collections.Generic;
using System.Security.Claims;
using Nmro.IAM.Domain;

namespace Nmro.IAM.API.Vms
{
    public class Client
    {
        public bool AllowOfflineAccess { get; set; }

        public int IdentityTokenLifetime { get; set; }

        public int AccessTokenLifetime { get; set; }

        public int AuthorizationCodeLifetime { get; set; }

        public int AbsoluteRefreshTokenLifetime { get; set; }

        public int SlidingRefreshTokenLifetime { get; set; }

        public int? ConsentLifetime { get; set; }

        public TokenUsage RefreshTokenUsage { get; set; }

        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        public TokenExpiration RefreshTokenExpiration { get; set; }

        public AccessTokenType AccessTokenType { get; set; }

        public bool EnableLocalLogin { get; set; }

        public ICollection<string> IdentityProviderRestrictions { get; set; }

        public bool IncludeJwtId { get; set; }

        public ICollection<Claim> Claims { get; set; }

        public bool AlwaysSendClientClaims { get; set; }

        public string ClientClaimsPrefix { get; set; }

        public string PairWiseSubjectSalt { get; set; }

        public int? UserSsoLifetime { get; set; }

        public string UserCodeType { get; set; }

        public int DeviceCodeLifetime { get; set; }

        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        public ICollection<string> AllowedScopes { get; set; }

        public IDictionary<string, string> Properties { get; set; }

        public bool BackChannelLogoutSessionRequired { get; set; }

        public bool Enabled { get; set; }

        public string ClientId { get; set; }

        public string ProtocolType { get; set; }

        public ICollection<Secret> ClientSecrets { get; set; }

        public bool RequireClientSecret { get; set; }

        public string ClientName { get; set; }

        public string Description { get; set; }

        public string ClientUri { get; set; }

        public string LogoUri { get; set; }

        public ICollection<string> AllowedCorsOrigins { get; set; }

        public bool RequireConsent { get; set; }

        public ICollection<string> AllowedGrantTypes { get; set; }

        public bool RequirePkce { get; set; }

        public bool AllowPlainTextPkce { get; set; }

        public bool AllowAccessTokensViaBrowser { get; set; }

        public ICollection<string> RedirectUris { get; set; }

        public ICollection<string> PostLogoutRedirectUris { get; set; }

        public string FrontChannelLogoutUri { get; set; }

        public bool FrontChannelLogoutSessionRequired { get; set; }

        public string BackChannelLogoutUri { get; set; }

        public bool AllowRememberConsent { get; set; }
    }
}
