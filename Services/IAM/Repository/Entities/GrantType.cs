using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Repository.Entities
{
    public static class GrantType
    {
        public const string Implicit = "implicit";
        public const string Hybrid = "hybrid";
        public const string AuthorizationCode = "authorization_code";
        public const string ClientCredentials = "client_credentials";
        public const string ResourceOwnerPassword = "password";
        public const string DeviceFlow = "urn:ietf:params:oauth:grant-type:device_code";
    }
}
