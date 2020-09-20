using Microsoft.EntityFrameworkCore;

namespace Nmro.Security.IAM.Infras.Storage
{
    public class IAMDbContextFactory : DesignTimeDbContextFactoryBase<IAMDbcontext>
    {
        protected override IAMDbcontext CreateNewInstance(DbContextOptions<IAMDbcontext> options)
        {
            return new IAMDbcontext(options);
        }
    }
}
