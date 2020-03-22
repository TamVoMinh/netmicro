using Nmro.Oidc.Models;
using System.Threading.Tasks;

namespace Nmro.Oidc.Services
{
    public interface IUserService
    {
        Task<User> ValidateCredentials(string username, string password);
    }
}
