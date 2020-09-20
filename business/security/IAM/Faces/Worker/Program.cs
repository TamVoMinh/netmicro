using Nmro.Hosting;

namespace Nmro.Security.IAM.Faces.Worker
{
    public class Program
    {
        public static readonly string AppName = "iam-worker";

        public static int Main(string[] args) => NmroWebHost.Build<Startup>(args);
    }
}
