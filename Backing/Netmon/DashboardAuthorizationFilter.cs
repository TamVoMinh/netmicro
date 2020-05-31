using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Nmro.Netmon
     {

    public class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }

}
