using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly string Key = "palindromo"; // 🔒 A chave deve ser mantida segura

        // Método para descriptografar o texto (CPF, no caso)
        public static string Decrypt(string encryptedText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
            byte[] buffer = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] result = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);
                    return Encoding.UTF8.GetString(result);
                }
            }
        }
    }
}
