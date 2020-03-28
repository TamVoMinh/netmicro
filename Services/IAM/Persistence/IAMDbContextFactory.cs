
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Nmro.IAM.Persistence
{
    public class IAMDbContextFactory : DesignTimeDbContextFactoryBase<IAMDbcontext>
    {
        protected override IAMDbcontext CreateNewInstance(DbContextOptions<IAMDbcontext> options)
        {
            return new IAMDbcontext(options);
        }
    }
}
