namespace Nmro.Oidc.Infrastructure
{
    public static class API
    {
        public static class IdentityUser
        {
            public static string GetUserByUsername(string username) => $"identityuser?username={username}";
            public static string ValidateCredentials() => $"identityuser/credential-validation";
        }

        public static class Client
        {
            public static string GetClientByClientId(string clientId) => $"client/oidc?clientId={clientId}";
        }

        public static class Resource
        {
            public static string GetApiResourceByName(string resourceName) => $"resources/api-resource/{resourceName}";

            public static string GetApiResourceByScope(string scopes) => $"resources/api-resource?{scopes}";

            public static string GetIdentityResourceByScope(string scopes) => $"resources/identity-resource?{scopes}";

            public static string GetAllResources() => $"resources";
        }
    }
}
