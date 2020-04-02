using System.Threading.Tasks;
using Nmro.Oidc.Infrastructure.IamClient.Models;

namespace Nmro.Oidc.Application
{
    public interface IUserService
    {
        Task<IdentityUser> ValidateCredential(string username, string password);
    }
}
