namespace Nmro.IAM.Application.Interfaces
{
    public interface IPasswordProcessor
    {
        string HashWithPbkdf2(string password, byte[] salt);

        string HashWithSha256(string rawString);

        byte[] GenerateSalt();

        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword, byte[] salt);
    }
}
