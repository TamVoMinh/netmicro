using Nmro.Hosting;

namespace Nmro.Landing
{
    public class Program
    {
        public static readonly string AppName = "landing";
        public static int Main(string[] args) => NmroWebHost.Build<Startup>(args);
    }
}
