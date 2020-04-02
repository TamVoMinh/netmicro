using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Nmro.Oidc.Infrastructure.IamClient.Models;

namespace Nmro.Oidc.Application
{
    public interface IExternalUserService:IUserService
    {

        Task<IdentityUser> AutoProvisionUser(string provider, string userId, List<Claim> claims);

        Task<IdentityUser> FindByExternalProvider(string provider, string userId);

        Task<IdentityUser> FindBySubjectId(string subjectId);

        Task<IdentityUser> FindByUsername(string username);
    }
}
