namespace Nmro.IAM.Domain.Entities
{
    public class Scope : EntityBase<long>
    {
        //
        // Summary:
        //     Name of the scope. This is the value a client will use to request the scope.
        public string Name { get; set; }

        public int ApiResourceId { get; set; }

        public ApiResource ApiResource { get; set; }
    }
}
