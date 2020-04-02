using System;
using System.Security.Cryptography;
using System.Text;

namespace Nmro.Common.Extentions
{
    /// <summary>
    /// Extension methods for hashing strings
    /// </summary>
    public static class HashExtensions
    {
        public static string Sha256(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string Sha512(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}
