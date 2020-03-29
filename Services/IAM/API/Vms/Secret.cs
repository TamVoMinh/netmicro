using System;

namespace Nmro.IAM.API.Vms
{
    public class Secret
    {

        public string Description { get; set; }

        public string Value { get; set; }

        public DateTime? Expiration { get; set; }

        public string Type { get; set; }
    }
}
