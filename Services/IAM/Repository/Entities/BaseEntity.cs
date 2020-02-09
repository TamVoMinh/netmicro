using System;

namespace Nmro.IAM.Reposistory.Entities
{
    public abstract class EntityBase<ID>
    {
        public ID Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

    }
}
