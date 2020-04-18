namespace Nmro.Web.ServiceDiscovery
{
    public class DiscoveryOptions
    {
        public string DiscoveryAddress { get; set; }
        public string ServiceName { get; set; }
        public int ServicePort { get; set; } = 80;

        public string HealthPath {get;set;} = "hc";
    }
}
