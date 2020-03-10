using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Nmro.IAM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nmro.IAM.Services
{
    public class PasswordValidator : IPasswordValidator
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
            var providedPasswordSHA256Hashed = HashWithSha256(providedPassword);
            var providedPasswordStrongHashed = HashWithPbkdf2(providedPasswordSHA256Hashed, salt);

            if (providedPasswordStrongHashed.Equals(hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }

        private string HashWithSha256(string input)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    public enum PasswordVerificationResult
    {
        Success,
        Failed
    }
}
