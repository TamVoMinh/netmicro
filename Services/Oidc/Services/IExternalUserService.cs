using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Nmro.Oidc.Models;

namespace Nmro.Oidc.Services
{
    public interface IExternalUserService: IUserService
    {
        // Summary:
        //     Automatically provisions a user.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        //
        //   claims:
        //     The claims.
        Task<User> AutoProvisionUser(string provider, string userId, List<Claim> claims);
        //
        // Summary:
        //     Finds the user by external provider.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        Task<User> FindByExternalProvider(string provider, string userId);
        //
        // Summary:
        //     Finds the user by subject identifier.
        //
        // Parameters:
        //   subjectId:
        //     The subject identifier.
        Task<User> FindBySubjectId(string subjectId);
        //
        // Summary:
        //     Finds the user by username.
        //
        // Parameters:
        //   username:
        //     The username.
        Task<User> FindByUsername(string username);
    }
}
