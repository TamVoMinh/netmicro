using System;

namespace Nmro.IAM.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Log.Information("Applying migrations");
            host.MigrateDbContext<IAMDbcontext>((context, services) =>
            {
                var logger = services.GetService<ILogger<IdentityUserContextSeed>>();
                var passwordValidator = services.GetService<IPasswordValidator>();

                new IdentityUserContextSeed(passwordValidator)
                    .SeedAsync(context, logger)
                    .Wait();
            });
        }
    }
}
