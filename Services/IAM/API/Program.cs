using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nmro.IAM.Core.UseCases.Systems;
using Nmro.IAM.Persistence;
using Nmro.Web;

namespace Nmro.IAM.API
{
    public class Program
    {
        public static readonly string AppName = "iam-api";

        public static int Main(string[] args)
            => NmroWebHost.Build<Startup>(args, async host => {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    var dbcontext = services.GetRequiredService<IAMDbcontext>();

                    dbcontext.Database.Migrate();

                    var mediator = services.GetRequiredService<IMediator>();
                    await mediator.Send(new SeedDataCommand(), CancellationToken.None);
                }
            });
    }
}
