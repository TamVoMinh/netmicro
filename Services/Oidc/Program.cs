using Nmro.Web;

namespace Nmro.Oidc
{
    public class Program
    {
        public static readonly string AppName = "oidc";

        public static int Main(string[] args) => NmroWebHost.Build<Startup>(args);
    }
}
