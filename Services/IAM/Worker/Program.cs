using Nmro.Web;
using Hangfire;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using Nmro.IAM.Application.UseCases.PersistedGrants.Commands;

namespace Nmro.IAM.Worker
{
    public class Program
    {
        public static readonly string AppName = "iam-async-worker";

        public static int Main(string[] args) => NmroWebHost.Build<Startup>(args);
    }
}
