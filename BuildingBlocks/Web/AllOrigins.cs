using System;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Nmro.Web
{
    public static class AllOrigins
    {
        public const string PolicyName = "all_cors_policy";

        public static Action<CorsOptions> SetUpPolicy = options
            => options.AddPolicy(AllOrigins.PolicyName, builder => AllOrigins.BuildPolicy(builder));

        private static void BuildPolicy(CorsPolicyBuilder builder)
            => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    }
}
