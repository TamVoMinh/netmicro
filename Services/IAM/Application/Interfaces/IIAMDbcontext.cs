using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nmro.IAM.Application.Interfaces
{
    public interface IIAMDbcontext
    {
        DbSet<IdentityUser> IdentityUsers { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<ApiResource> ApiResources { get; set; }
        DbSet<IdentityResource> IdentityResources { get; set; }
        DbSet<Scope> Scopes { get; set; }
        DbSet<Secret> Secrets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
