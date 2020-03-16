using System;

namespace Nmro.Web.ServiceDiscovery
{
    public class ConfigurationOptions
    {
        public Uri DiscoveryAddress { get; set; }
        public string ServiceName { get; set; }

        public int ServicePort { get; set; }
    }
}
