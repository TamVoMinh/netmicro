using Nmro.Hosting;
using Ocelot.DependencyInjection;

namespace Nmro.Foundation.Backbone.ApiGateway
{
    public class Program
    {
        public static readonly string AppName = "apigateway";

        public static int Main(string[] args)
            => NmroWebHost.BuildWebHost<Startup>(args, (hostingContext, config) =>{
                    config.AddOcelot(hostingContext.HostingEnvironment);
            });
    }
}
