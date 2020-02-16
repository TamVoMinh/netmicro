using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nmro.IAM.Reposistory;
using Nmro.IAM.Reposistory.Entities;
using Npgsql;
using Polly;
using Polly.Retry;

public class IdentityUserContextSeed
{
    public async Task SeedAsync(IAMDbcontext context, ILogger<IdentityUserContextSeed> logger)
    {
        var policy = CreatePolicy(logger, nameof(IdentityUserContextSeed));

        logger.LogInformation("Start seeding...");

        await policy.ExecuteAsync(async () =>
        {
            if (!context.IdentityUsers.Any())
            {
                await context.IdentityUsers.AddRangeAsync(SeedUsers());
                await context.SaveChangesAsync();
            }
        });

        logger.LogInformation("End seeding.");
    }

    private List<IdentityUser> SeedUsers()
    {
        return new List<IdentityUser>{
            new IdentityUser{ UserName = "admin", Password="admin123", Email="admin@nmro.local" }
        };
    }

    private AsyncRetryPolicy CreatePolicy(ILogger<IdentityUserContextSeed> logger, string prefix, int retries = 3)
    {
        return Policy.Handle<NpgsqlException>().
            WaitAndRetryAsync(
                retryCount: retries,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                }
            );
    }
}
