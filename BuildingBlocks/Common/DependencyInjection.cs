using Microsoft.Extensions.DependencyInjection;
using Nmro.Common.Services;

namespace Nmro.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
            => services.AddTransient<IDateTime, MachineDateTime>();

    }

}
