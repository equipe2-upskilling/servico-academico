using System.Security.Cryptography;
using System.Text;
using System;

namespace Academic.Core
{
    public class CryptoHelper
    {
        public string GetSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public string Encrypt(string value, string salt)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] hashBytes;
            using (var sha256 = SHA256.Create())
            {
                byte[] valueWithSaltBytes = new byte[valueBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(valueBytes, 0, valueWithSaltBytes, 0, valueBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, valueWithSaltBytes, valueBytes.Length, saltBytes.Length);

                hashBytes = sha256.ComputeHash(valueWithSaltBytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
        public string Decrypt(string encryptedValue, string salt)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedValue);
            byte[] saltBytes = Convert.FromBase64String(salt);

            using (var sha256 = SHA256.Create())
            {
                byte[] valueWithSaltBytes = new byte[encryptedBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(encryptedBytes, 0, valueWithSaltBytes, 0, encryptedBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, valueWithSaltBytes, encryptedBytes.Length, saltBytes.Length);

                byte[] decryptedBytes = sha256.ComputeHash(valueWithSaltBytes);

                // Assuming that the original value was a UTF-8 string
                string decryptedValue = Encoding.UTF8.GetString(decryptedBytes);

                return decryptedValue;
            }
        }
    }
}
