using Nmro.Web;

namespace Nmro.IAM.Worker
{
    public class Program
    {
        public static readonly string AppName = "iam-async-worker";

        public static int Main(string[] args) => NmroWebHost.Build<Startup>(args);
    }
}
