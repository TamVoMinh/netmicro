using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Nmro.Oidc.Infrastructure.IamClient.Models;

namespace Nmro.Oidc.Application
{
    public class ExternalUserService : IExternalUserService
    {
        public Task<IdentityUser> AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityUser> FindByExternalProvider(string provider, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityUser> FindBySubjectId(string subjectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityUser> FindByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityUser> ValidateCredential(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
