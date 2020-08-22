using Microsoft.Extensions.DependencyInjection;

namespace Nmro.Oidc.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIamRestClient(this IServiceCollection services)
        {
            services.AddScoped<IamClient.IRestOidc, IamClient.RestOidc>();

            return services;
        }
    }
}
