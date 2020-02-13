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
            return configuration.GetValue<string[]>("AllowedHosts") ?? new string[] {"*"};
        }
    }
}
