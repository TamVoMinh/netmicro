using System.Collections.Generic;

namespace Nmro.IAM.Repository.Entities
{
    public class Resource : EntityBase<int>
    {
        //
        // Summary:
        //     Indicates if this resource is enabled. Defaults to true.
        public bool Enabled { get; set; }
        //
        // Summary:
        //     The unique name of the resource.
        public string Name { get; set; }
        //
        // Summary:
        //     Display name of the resource.
        public string DisplayName { get; set; }
        //
        // Summary:
        //     Description of the resource.
        public string Description { get; set; }
        //
        // Summary:
        //     List of accociated user claims that should be included when this resource is
        //     requested.
        public ICollection<string> UserClaims { get; set; }
    }
}
