using Nmro.Web;
using Ocelot.DependencyInjection;

namespace Nmro.ApiGateway
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
