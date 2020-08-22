using Microsoft.Extensions.DependencyInjection;
using Nmro.Shared.Services;

namespace Nmro.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
            => services.AddTransient<IDateTime, MachineDateTime>();

    }

}
