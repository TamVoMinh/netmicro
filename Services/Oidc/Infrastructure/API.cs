namespace Nmro.Oidc.Infrastructure
{
    public static class API
    {
        public static class IdentityUser
        {
            public static string ValidateCredentials() => $"oidc/users/validate";
        }

        public static class Client
        {
            public static string GetClientByClientId(string clientId) => $"oidc/clients/{clientId}";
        }

        public static class Resource
        {
            public static string GetApiResourceByName(string resourceName) => $"oidc/resources/apis/{resourceName}";

            public static string GetApiResourceByScope(string scopes) => $"oidc/resources/apis?{scopes}";

            public static string GetIdentityResourceByScope(string scopes) => $"oidc/resources/identities?{scopes}";

            public static string GetAllResources() => $"oidc/resources";
        }
    }
}
