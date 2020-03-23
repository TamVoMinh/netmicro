using System.Threading.Tasks;

namespace Nmro.IAM.Services
{
    public interface IUserService<T>
    {
        Task<T> FindByUsername(string username);
        Task<bool> ValidateCredentials(string username, string password);
    }
}
