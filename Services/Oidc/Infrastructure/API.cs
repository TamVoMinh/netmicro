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
            public static string GetClientById(string clientId) => $"client?clientId={clientId}";
        }

        public static class Resource
        {
            public static string GetApiResourceByName(string resourcename) => $"resources/api-resource/name?resourcename={resourcename}";

            public static string GetApiResourceByScope(string scopes) => $"resources/api-resource?{scopes}";

            public static string GetIdentityResourceByScope(string scopes) => $"resources/identity-resource?{scopes}";

            public static string GetAllResources() => $"resources";
        }
    }
}
