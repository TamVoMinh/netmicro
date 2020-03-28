using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Nmro.IAM.Application.Interfaces
{
    public interface IIAMDbcontext
    {
        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        public DbSet<Client> Clients { get; set; }
        /// <summary>
        /// Gets or sets the identity resources.
        /// </summary>
        /// <value>
        /// The identity resources.
        /// </value>
        public DbSet<IdentityResource> IdentityResources { get; set; }
        /// <summary>
        /// Gets or sets the API resources.
        /// </summary>
        /// <value>
        /// The API resources.
        /// </value>
        public DbSet<ApiResource> ApiResources { get; set; }
        /// <summary>
        /// Gets or sets the API scopes.
        /// </summary>
        /// <value>
        /// The API resources.
        /// </value>
        public DbSet<ApiScope> ApiScopes { get; set; }
        /// <summary>
        /// Gets or sets the User credentals.
        /// </summary>
        /// <value>
        /// The Identity Users.
        /// </value>
        DbSet<IdentityUser> IdentityUsers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
