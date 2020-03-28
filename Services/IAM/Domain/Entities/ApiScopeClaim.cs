namespace Nmro.IAM.Domain.Entities
{
    public class ApiScopeClaim : UserClaim
    {
        public int ScopeId { get; set; }
        public ApiScope Scope { get; set; }
    }
}
