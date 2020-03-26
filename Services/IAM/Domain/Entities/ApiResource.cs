using System.Collections.Generic;

namespace Nmro.IAM.Domain.Entities
{
    public class ApiResource : Resource
    {
        //
        // Summary:
        //     The API secret is used for the introspection endpoint. The API can authenticate
        //     with introspection using the API name and secret.
        public ICollection<Secret> ApiSecrets { get; set; }
        //
        // Summary:
        //     An API must have at least one scope. Each scope can have different settings.
        public ICollection<Scope> Scopes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
