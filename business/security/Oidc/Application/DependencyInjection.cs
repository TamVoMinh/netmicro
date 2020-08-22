using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nmro.Oidc.Application.Storages;
using Nmro.Oidc.Infrastructure;
using Nmro.Oidc.Infrastructure.Redis;

namespace Nmro.Oidc.Application
{
    public static class DependencyInjection
    {
        public static IIdentityServerBuilder AddIdentityServer4Stores(this IIdentityServerBuilder builder, IConfiguration configuration) =>
             builder
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourceStore>()
                .AddPersistedGrantStore<PersistedGrantStore>();

        public static IServiceCollection AddUserStore(this IServiceCollection services) =>
             services
                .AddIamRestClient()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IExternalUserService, ExternalUserService>();
    }

}
