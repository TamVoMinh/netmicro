using Microsoft.Extensions.Configuration;

namespace Nmro.Oidc.Extensions
{
    public static class CorsPolicyExtention
    {
        public static string GetCorsPolicyName(this IConfiguration configuration)
        {
            return configuration.GetValue<string>("CorsPolicyName");
        }

         public static string[] GetAllowOrigns(this IConfiguration configuration)
        {
            return configuration.GetSection("AllowedHosts").Get<string[]>();
        }
    }
}
