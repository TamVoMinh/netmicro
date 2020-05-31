using Nmro.Web;
namespace Nmro.Netmon
{
    public class Program
    {
        public static readonly string AppName = "netmon";

        public static int Main(string[] args) => NmroWebHost.Build<Startup>(args);

    }
}
