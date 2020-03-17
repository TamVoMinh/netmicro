using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Nmro.Oidc.Services
{
    public class RedisOptions
    {
        public static IConnectionMultiplexer GetConnectionMultiplexer(IConfiguration configuration)
        {
            return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"));
        }
    }
}
