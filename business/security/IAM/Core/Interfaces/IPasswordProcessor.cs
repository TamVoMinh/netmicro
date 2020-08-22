namespace Nmro.Security.IAM.Core.Interfaces
{
    public interface IPasswordProcessor
    {
        string HashWithPbkdf2(string password, byte[] salt);

        byte[] GenerateSalt();

        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword, byte[] salt);
    }
}
