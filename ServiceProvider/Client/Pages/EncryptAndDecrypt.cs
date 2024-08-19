using System.Security.Cryptography;
using System.Text;

namespace ServiceProvider.Client.Pages
{
    public class EncryptAndDecrypt
    {
        public static string Encrypt(string plainText, byte[] publicKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(publicKey, out _);
                byte[] data = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string cipherText, byte[] privateKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(privateKey, out _);
                byte[] data = Convert.FromBase64String(cipherText);
                byte[] decrypted = rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }
}
