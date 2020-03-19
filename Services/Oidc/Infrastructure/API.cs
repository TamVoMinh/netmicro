namespace Nmro.Oidc.Infrastructure
{
    public static class API
    {
        public static class IdentityUser
        {
            public static string ValidateCredentials() => $"identityuser/oidc/credential-validation";
        }

        public static class Client
        {
            public static string GetClientByClientId(string clientId) => $"client/oidc?clientId={clientId}";
        }

        public static class Resource
        {
            public static string GetApiResourceByName(string resourceName) => $"resources/oidc/api-resource/name={resourceName}";

            public static string GetApiResourceByScope(string scopes) => $"resources/oidc/api-resource?{scopes}";

            public static string GetIdentityResourceByScope(string scopes) => $"resources/oidc/identity-resource?{scopes}";

            public static string GetAllResources() => $"resources/oidc";
        }
    }
}
