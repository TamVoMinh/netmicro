using Nmro.Oidc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.Oidc.Services
{
    public partial interface IUserService
    {
        Task<User> FindByUsername(string username);
        Task<bool> ValidateCredentials(string username, string password);
    }
}
