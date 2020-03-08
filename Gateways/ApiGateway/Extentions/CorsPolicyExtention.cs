using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Nmro.ApiGateway.Extentions
{
    public static class CorsPolicyExtention
    {
        public static string GetCorsPolicyName(this IConfiguration configuration)
        {
            return configuration.GetValue<string>("CorsPolicyName") ?? "nmro_cors_policy";
        }

        public static string[] GetAllowOrigns(this IConfiguration configuration)
        {
            string optionsValue = configuration.GetValue<string>("AllowedOrigins");
            string[] origins = optionsValue.Split(",");

            return origins != null && origins.Length > 0
                ? origins.Where(origin => !string.IsNullOrEmpty(origin)).Select(origin => origin.Trim()).ToArray()
                : null;
        }
    }
}
