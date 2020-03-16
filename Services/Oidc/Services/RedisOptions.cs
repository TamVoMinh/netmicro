using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.Oidc.Services
{
    public class RedisOptions
    {
        public static IConnectionMultiplexer GetConnectionMultiplexer(IConfiguration configuration)
        {
            return ConnectionMultiplexer.Connect(configuration.GetConnectionString("ConnectionString"));
        }
    }
}
