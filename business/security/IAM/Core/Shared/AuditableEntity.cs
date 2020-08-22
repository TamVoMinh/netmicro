using System;
namespace Nmro.Security.IAM.Core
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
