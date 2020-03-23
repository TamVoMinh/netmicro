using System;

namespace Nmro.IAM.Models
{
    public class BaseEntityModel<ID>
    {
        public ID Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
