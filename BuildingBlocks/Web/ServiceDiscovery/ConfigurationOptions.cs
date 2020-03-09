using System;

namespace Nmro.BuildingBlocks.Web.ServiceDiscovery
{
    public class ConfigurationOptions
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
}
