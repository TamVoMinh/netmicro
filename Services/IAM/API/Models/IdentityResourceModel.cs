namespace Nmro.IAM.Models
{
    public class IdentityResourceModel : ResourceBaseModel
    {
        public bool Required { get; set; }

        public bool Emphasize { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }
    }
}
