using System;

namespace Nmro.IAM.Application.Models
{
    public class AuditableModel
    {
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }
}
