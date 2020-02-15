using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Services
{
    public interface IUserService<T>
    {
        Task<T> FindByUsername(string username);
        Task<bool> ValidateCredentials(string username, string password);
    }
}
