namespace Nmro.Oidc.Infrastructure.IamClient.Models{
    public class IdentityResource : Resource
    {
        public bool Required { get; set; } = false;

        public bool Emphasize { get; set; } = false;
    }
}
