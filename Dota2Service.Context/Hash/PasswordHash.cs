using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace Dota2Service.UserService.Hash
{
    public class PasswordHash
    {
        public static byte[] GeneratorSlat()
        {
            byte[] salt = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }
        public static string EncryptorPassword(string password, byte[] salt)
        {
            using var rfc = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), salt, 100_000, HashAlgorithmName.SHA512);
            byte[] hash = rfc.GetBytes(64);
            byte[] hashBytes = new byte[16 + 64];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
            Buffer.BlockCopy(hash, 0, hashBytes, 16, 64);
            return Convert.ToBase64String(hashBytes);
        }
        public static bool VerifyPassword(string enteredPassword, string storedHashBase64)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHashBase64);

            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, 16);
            string hash = EncryptorPassword(enteredPassword, salt);
            return CryptographicOperations.
                FixedTimeEquals(
                Encoding.UTF8.GetBytes(hash), 
                Encoding.UTF8.GetBytes(storedHashBase64));
        }
    }
}
