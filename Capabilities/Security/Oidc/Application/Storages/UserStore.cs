using System.Threading.Tasks;
using Nmro.Oidc.Infrastructure.IamClient;
using Nmro.Oidc.Infrastructure.IamClient.Models;

namespace Nmro.Oidc.Application.Storages
{
    public class UserService : IUserService
    {
        private readonly IRestOidc _restOidc;
        public UserService(IRestOidc restOidc)
        {
            _restOidc = restOidc;
        }

        public async Task<IdentityUser> ValidateCredential(string username, string password)
        {
            return await _restOidc.ValidateCredential(username, password);
        }
    }
}
