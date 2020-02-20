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
            public static string CreateNewIdentityUser() => $"identity";

            public static string GetUserByUsername(string username) => $"identity?username={username}";
            public static string ValidateCredentials() => $"identity/credential-validation";
        }

        public static class Client
        {
            public static string GetClientById(string clientId) => $"client?clientId={clientId}";
        }
    }
}
