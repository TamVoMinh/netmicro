using Nmro.Web;
namespace Nmro.Health
{
    public class Program
    {
        public static readonly string AppName = "health";

        public static int Main(string[] args) => NmroWebHost.Build<Startup>(args);

    }
}
