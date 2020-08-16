using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Nmro.IAM.Core.Interfaces;
using System;
using System.Security.Cryptography;

namespace Nmro.IAM.Core
{
    public class PasswordProcessor : IPasswordProcessor
    {
        public string HashWithPbkdf2(string rawString, byte[] salt)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: rawString,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public byte[] GenerateSalt()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword, byte[] salt)
        {
            var providedPasswordStrongHashed = HashWithPbkdf2(providedPassword, salt);

            if (providedPasswordStrongHashed.Equals(hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }
    }

    public enum PasswordVerificationResult
    {
        Success,
        Failed
    }
}
