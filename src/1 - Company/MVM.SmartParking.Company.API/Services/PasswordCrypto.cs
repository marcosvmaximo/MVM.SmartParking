using System.Security.Cryptography;

namespace MVM.SmartParking.Company.API.Services;

public static class PasswordCrypto
{
    public static string GenerateHashPassword(string password)
    {
        byte[] salt = new byte[16];
        
        var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(salt);
        
        Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000, HashAlgorithmName.SHA256);
        
        byte[] hash = pbkdf2.GetBytes(20);
        byte[] hashBytes = new byte[36];

        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        return Convert.ToBase64String(hashBytes);
    }
}