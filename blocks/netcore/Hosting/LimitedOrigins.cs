using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Nmro.Hosting
{
    public static class WILDCARD
    {
        public const string ALL = "*";
    }

    public class CorsPolicyConfigOptions
    {
        public string PolicyName {get;set;}
        public IEnumerable<string> AllowedOrigins {get;set;} = new string[] {WILDCARD.ALL};
        public IEnumerable<string> AllowedHeaders {get;set;} = new string[] {WILDCARD.ALL};
        public IEnumerable<string> AllowedMethods {get;set;} = new string[] {WILDCARD.ALL};

    }
    public static class LimitedOrigins
    {

        public static Action<CorsOptions, CorsPolicyConfigOptions> Bind = (options, configOptions)
            => options.AddPolicy(configOptions.PolicyName, builder => BuildPolicy(builder, configOptions));

        private static void BuildPolicy(CorsPolicyBuilder builder, CorsPolicyConfigOptions configOptions)
            => builder
                .BuildOrigins(configOptions)
                .BuildHeaders(configOptions)
                .BuildMethods(configOptions);

         private static CorsPolicyBuilder BuildOrigins(this CorsPolicyBuilder builder, CorsPolicyConfigOptions configOptions)
            => configOptions.AllowedOrigins.Any( o => o.Equals(WILDCARD.ALL))
                ? builder.AllowAnyOrigin()
                : builder.WithOrigins(configOptions.AllowedOrigins.ToArray());

        private static CorsPolicyBuilder BuildHeaders(this CorsPolicyBuilder builder, CorsPolicyConfigOptions configOptions)
            => configOptions.AllowedHeaders.Any( o => o.Equals(WILDCARD.ALL))
                ? builder.AllowAnyHeader()
                : builder.WithHeaders(configOptions.AllowedHeaders.ToArray());

        private static CorsPolicyBuilder BuildMethods(this CorsPolicyBuilder builder, CorsPolicyConfigOptions configOptions)
            => configOptions.AllowedMethods.Any( o => o.Equals(WILDCARD.ALL))
                ? builder.AllowAnyMethod()
                : builder.WithMethods(configOptions.AllowedMethods.ToArray());
    }
}
