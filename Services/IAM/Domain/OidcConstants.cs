
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
namespace Nmro.IAM.Domain
{
    public static class OidcConstants
    {
        public static class ProtocolTypes
        {
            public const string OpenIdConnect = "oidc";
            public const string WsFederation = "wsfed";
            public const string Saml2p = "saml2p";
        }
        public static class TokenTypes
        {
            public const string IdentityToken = "id_token";
            public const string AccessToken = "access_token";
        }
        public static class ClaimValueTypes
        {
            public const string Json = "json";
        }
        public static class ParsedSecretTypes
        {
            public const string NoSecret = "NoSecret";
            public const string SharedSecret = "SharedSecret";
            public const string X509Certificate = "X509Certificate";
            public const string JwtBearer = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";
        }
        public static class SecretTypes
        {
            public const string SharedSecret = "SharedSecret";
            public const string X509CertificateThumbprint = "X509Thumbprint";
            public const string X509CertificateName = "X509Name";
            public const string X509CertificateBase64 = "X509CertificateBase64";
            public const string JsonWebKey = "JWK";
        }
        public static class ProfileDataCallers
        {
            public const string UserInfoEndpoint = "UserInfoEndpoint";
            public const string ClaimsProviderIdentityToken = "ClaimsProviderIdentityToken";
            public const string ClaimsProviderAccessToken = "ClaimsProviderAccessToken";
        }
        public static class ProfileIsActiveCallers
        {
            public const string AuthorizeEndpoint = "AuthorizeEndpoint";
            public const string IdentityTokenValidation = "IdentityTokenValidation";
            public const string AccessTokenValidation = "AccessTokenValidation";
            public const string ResourceOwnerValidation = "ResourceOwnerValidation";
            public const string ExtensionGrantValidation = "ExtensionGrantValidation";
            public const string RefreshTokenValidation = "RefreshTokenValidation";
            public const string AuthorizationCodeValidation = "AuthorizationCodeValidation";
            public const string UserInfoRequestValidation = "UserInfoRequestValidation";
            public const string DeviceCodeValidation = "DeviceCodeValidation";
        }
        public static IEnumerable<string> SupportedSigningAlgorithms = new List<string>
        {
            SecurityAlgorithms.RsaSha256,
            SecurityAlgorithms.RsaSha384,
            SecurityAlgorithms.RsaSha512,
            SecurityAlgorithms.RsaSsaPssSha256,
            SecurityAlgorithms.RsaSsaPssSha384,
            SecurityAlgorithms.RsaSsaPssSha512,
            SecurityAlgorithms.EcdsaSha256,
            SecurityAlgorithms.EcdsaSha384,
            SecurityAlgorithms.EcdsaSha512,
        };
        public enum RsaSigningAlgorithm
        {
            RS256,
            RS384,
            RS512,
            PS256,
            PS384,
            PS512
        };
        public enum ECDsaSigningAlgorithm
        {
            ES256,
            ES384,
            ES512
        }
        public static class StandardScopes
        {
            public const string OpenId = "openid";
            public const string Profile = "profile";
            public const string Email = "email";
            public const string Address = "address";
            public const string Phone = "phone";
            public const string OfflineAccess = "offline_access";
        }
        public static class PersistedGrantTypes
        {
            public const string AuthorizationCode = "authorization_code";
            public const string ReferenceToken = "reference_token";
            public const string RefreshToken = "refresh_token";
            public const string UserConsent = "user_consent";
            public const string DeviceCode = "device_code";
            public const string UserCode = "user_code";
        }
        public static class UserCodeTypes
        {
            public const string Numeric = "Numeric";
        }
    }
}
