using System;

namespace Nmro.IAM.Application.Models
{
    public class AuditableModel
    {
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
