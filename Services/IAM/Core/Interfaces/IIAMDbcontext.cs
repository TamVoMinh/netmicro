using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Nmro.IAM.Core.Interfaces
{
    public interface IIAMDbcontext
    {
        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        DbSet<Client> Clients { get; set; }
        /// <summary>
        /// Gets or sets the identity resources.
        /// </summary>
        /// <value>
        /// The identity resources.
        /// </value>
        DbSet<IdentityResource> IdentityResources { get; set; }
        /// <summary>
        /// Gets or sets the API resources.
        /// </summary>
        /// <value>
        /// The API resources.
        /// </value>
        DbSet<ApiResource> ApiResources { get; set; }
        /// <summary>
        /// Gets or sets the API scopes.
        /// </summary>
        /// <value>
        /// The API resources.
        /// </value>
        DbSet<ApiScope> ApiScopes { get; set; }
        /// <summary>
        /// Gets or sets the User credentals.
        /// </summary>
        /// <value>
        /// The Identity Users.
        /// </value>
        DbSet<IdentityUser> IdentityUsers { get; set; }

        DbSet<PersistedGrant> PersistedGrants { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
