using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Nmro.Oidc.Models;

namespace Nmro.Oidc.Services
{
    public class ExternalUserService : IExternalUserService
    {
        public Task<User> AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByExternalProvider(string provider, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindBySubjectId(string subjectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ValidateCredentials(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
