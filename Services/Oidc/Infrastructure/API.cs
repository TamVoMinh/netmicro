using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.Oidc.Infrastructure
{
    public static class API
    {
        public static class IdentityUser
        {
            public static string GetAllIdentityUsers() => $"identityuser";
            public static string GetUserById(long id) => $"identityuser/{id}";
            public static string CreateNewIdentityUser() => $"identityuser";
            public static string UpdateIdentityUser() => $"identityuser";
            public static string GetUserByUsername(string username) => $"identityuser?username={username}";
            public static string ValidateCredentials() => $"identityuser/credential-validation";
            public static string DeleteIdentityUser(long id) => $"identityuser/{id}";
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
