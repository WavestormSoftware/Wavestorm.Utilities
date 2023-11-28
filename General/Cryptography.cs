namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        /// <summary>
        /// Provides methods for encrypting and decrypting data.
        /// </summary>
        public static class Cryptography
        {
            /// <summary>
            /// Encode a string using Base64.
            /// </summary>
            /// <param name="plainText">The string to encode.</param>
            /// <returns>An encoded string.</returns>
            public static string EncodeBase64(string plainText)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }

            /// <summary>
            /// Decode a string using Base64.
            /// </summary>
            /// <param name="base64EncodedData">The string to decode.</param>
            /// <returns>A decoded string.</returns>
            public static string DecodeBase64(string base64EncodedData)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }

            /// <summary>
            /// Encrypt a string using AES.
            /// </summary>
            /// <param name="plainText">The string to encrypt.</param>
            /// <param name="key">The encryption key.</param>
            /// <returns>An encrypted string.</returns>
            public static string EncryptString(string plainText, string key)
            {
                var iv = new byte[16];
                var array = System.Text.Encoding.UTF8.GetBytes(plainText);
                using var aes = System.Security.Cryptography.Aes.Create();
                aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using var memoryStream = new System.IO.MemoryStream();
                using (var cryptoStream = new System.Security.Cryptography.CryptoStream((System.IO.Stream)memoryStream,
                           encryptor, System.Security.Cryptography.CryptoStreamMode.Write))
                {
                    cryptoStream.Write(array, 0, array.Length);
                }

                return System.Convert.ToBase64String(memoryStream.ToArray());
            }

            /// <summary>
            /// Decrypt a string using AES.
            /// </summary>
            /// <param name="cipherText">The string to decrypt.</param>
            /// <param name="key">The encryption key.</param>
            /// <returns>A decrypted string.</returns>
            public static string DecryptString(string cipherText, string key)
            {
                var iv = new byte[16];
                var buffer = System.Convert.FromBase64String(cipherText);
                using var aes = System.Security.Cryptography.Aes.Create();
                aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using var memoryStream = new System.IO.MemoryStream(buffer);
                using var cryptoStream = new System.Security.Cryptography.CryptoStream((System.IO.Stream)memoryStream,
                    decryptor, System.Security.Cryptography.CryptoStreamMode.Read);
                var num = new byte[buffer.Length];
                var count = cryptoStream.Read(num, 0, num.Length);
                return System.Text.Encoding.UTF8.GetString(num, 0, count);
            }

            /// <summary>
            /// Encrypt a string using RSA.
            /// </summary>
            /// <param name="plainText">The string to encrypt.</param>
            /// <param name="publicKey">The public key.</param>
            /// <returns>An encrypted string.</returns>
            public static string EncryptStringRSA(string plainText, string publicKey)
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                using var rsa = System.Security.Cryptography.RSA.Create();
                rsa.FromXmlString(publicKey);
                var inArray = rsa.Encrypt(bytes, System.Security.Cryptography.RSAEncryptionPadding.Pkcs1);
                return System.Convert.ToBase64String(inArray);
            }

            /// <summary>
            /// Decrypt a string using RSA.
            /// </summary>
            /// <param name="cipherText">The string to decrypt.</param>
            /// <param name="privateKey">The private key.</param>
            /// <returns>A decrypted string.</returns>
            public static string DecryptStringRSA(string cipherText, string privateKey)
            {
                var bytes = System.Convert.FromBase64String(cipherText);
                using var rsa = System.Security.Cryptography.RSA.Create();
                rsa.FromXmlString(privateKey);
                var inArray = rsa.Decrypt(bytes, System.Security.Cryptography.RSAEncryptionPadding.Pkcs1);
                return System.Text.Encoding.UTF8.GetString(inArray);
            }
        }
    }
}