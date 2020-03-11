using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Services
{
    public interface IPasswordValidator
    {
        string HashWithPbkdf2(string password, byte[] salt);

        string HashWithSha256(string rawString);

        byte[] GenerateSalt();

        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword, byte[] salt);
    }
}
