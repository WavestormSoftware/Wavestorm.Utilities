namespace Wavestorm.Utilities;

public partial class Utilities
{
    public class General
    {
        /// <summary>
        /// Get a new UUID (Universally Unique Identifier).
        /// </summary>
        /// <returns>A string representation of a new UUID.</returns>
        public static string GetUUID()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Get a random integer between two values.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>A random integer between the minimum and maximum values.</returns>
        public static int GetRandomInt(int min, int max)
        {
            return new System.Random().Next(min, max);
        }

        /// <summary>
        /// Get a random string of a specified length.
        /// </summary>
        /// <param name="length">The length of the string.</param>
        /// <param name="useNumbers">Include numbers in the random string.</param>
        /// <param name="useSpecialCharacters">Include special characters in the random string.</param>
        /// <returns>A random string of the specified length.</returns>
        public static string GetRandomString(int length, bool useNumbers = false, bool useSpecialCharacters = false)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string charsNumbers = "0123456789";
            const string charsSpecial = "!@#$%^&*()_+";

            var allowedChars = chars;

            if (useNumbers && useSpecialCharacters)
            {
                allowedChars += charsNumbers + charsSpecial;
            }
            else if (useNumbers)
            {
                allowedChars += charsNumbers;
            }
            else if (useSpecialCharacters)
            {
                allowedChars += charsSpecial;
            }

            return new string(Enumerable.Repeat(allowedChars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Convert a string to a byte array.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>A byte array representation of the string.</returns>
        public static byte[] StringToByteArray(string str)
        {
            return System.Text.Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// Convert a byte array to a string.
        /// </summary>
        /// <param name="bytes">The byte array to convert.</param>
        /// <returns>A string representation of the byte array.</returns>
        public static string ByteArrayToString(byte[] bytes)
        {
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Check if an input is null or empty.
        /// </summary>
        /// <typeparam name="T">The type of input to check.</typeparam>
        /// <param name="input">The input to check.</param>
        /// <returns>True if the input is null or empty, false otherwise.</returns>
        public static bool IsNullOrEmpty<T>(T input)
        {
            if (EqualityComparer<T>.Default.Equals(input, default(T)))
            {
                return true;
            }

            if (input is string str)
            {
                return string.IsNullOrEmpty(str);
            }

            if (input is System.Collections.IEnumerable enumerable)
            {
                // Check if the collection is empty
                return !enumerable.Cast<object>().Any();
            }

            return false;
        }

        /// <summary>
        /// Check if a string is a valid email address.
        /// </summary>
        /// <param name="email">The string to check.</param>
        /// <returns>True if the string is a valid email address, false otherwise.</returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if a string is a valid URL.
        /// </summary>
        /// <param name="url">The string to check.</param>
        /// <returns>True if the string is a valid URL, false otherwise.</returns>
        public static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

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

        /// <summary>
        /// Compress a string using GZip.
        /// </summary>
        /// <param name="text">The string to compress.</param>
        /// <returns>A compressed string.</returns>
        public static string CompressString(string text)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(text);
            var memoryStream = new System.IO.MemoryStream();
            using (var gZipStream = new System.IO.Compression.GZipStream((System.IO.Stream)memoryStream,
                       System.IO.Compression.CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0L;
            var array = new byte[memoryStream.Length];
            memoryStream.Read(array, 0, array.Length);
            var array2 = new byte[array.Length + 4];
            System.Buffer.BlockCopy(array, 0, array2, 4, array.Length);
            System.Buffer.BlockCopy(System.BitConverter.GetBytes(buffer.Length), 0, array2, 0, 4);
            return System.Convert.ToBase64String(array2);
        }

        /// <summary>
        /// Decompress a string using GZip.
        /// </summary>
        /// <param name="compressedText">The string to decompress.</param>
        /// <returns>A decompressed string.</returns>
        public static string DecompressString(string compressedText)
        {
            var array = System.Convert.FromBase64String(compressedText);
            using var memoryStream = new System.IO.MemoryStream();
            var num = System.BitConverter.ToInt32(array, 0);
            memoryStream.Write(array, 4, array.Length - 4);
            var array2 = new byte[num];
            memoryStream.Position = 0L;
            using (var gZipStream = new System.IO.Compression.GZipStream((System.IO.Stream)memoryStream,
                       System.IO.Compression.CompressionMode.Decompress))
            {
                gZipStream.Read(array2, 0, array2.Length);
            }

            return System.Text.Encoding.UTF8.GetString(array2);
        }

        /// <summary>
        /// Serialize an object to a JSON string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string SerializeObject(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }

        /// <summary>
        /// Deserialize a JSON string to an object.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>An object representation of the JSON string.</returns>
        public static object DeserializeObject(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<object>(json);
        }

        /// <summary>
        /// Get the value of a property from an object.
        /// </summary>
        /// <param name="obj">The object to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the value of.</param>
        /// <returns>The value of the property.</returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
        }

        /// <summary>
        /// Set the value of a property on an object.
        /// </summary>
        /// <param name="obj">The object to set the property value on.</param>
        /// <param name="propertyName">The name of the property to set the value of.</param>
        /// <param name="value">The value to set the property to.</param>
        /// <returns>True if the property was set, false otherwise.</returns>
        public static bool SetPropertyValue(object obj, string propertyName, object value)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
            {
                return false;
            }

            propertyInfo.SetValue(obj, value, null);
            return true;
        }

        /// <summary>
        /// Get the value of a field from an object.
        /// </summary>
        /// <param name="obj">The object to get the field value from.</param>
        /// <param name="fieldName">The name of the field to get the value of.</param
        /// <returns>The value of the field.</returns>
        public static object GetFieldValue(object obj, string fieldName)
        {
            return obj.GetType().GetField(fieldName)?.GetValue(obj);
        }

        /// <summary>
        /// Set the value of a field on an object.
        /// </summary>
        /// <param name="obj">The object to set the field value on.</param>
        /// <param name="fieldName">The name of the field to set the value of.</param>
        /// <param name="value">The value to set the field to.</param>
        /// <returns>True if the field was set, false otherwise.</returns>
        public static bool SetFieldValue(object obj, string fieldName, object value)
        {
            var fieldInfo = obj.GetType().GetField(fieldName);
            if (fieldInfo == null)
            {
                return false;
            }

            fieldInfo.SetValue(obj, value);
            return true;
        }

        /// <summary>
        /// Get the current Unix timestamp.
        /// </summary>
        /// <returns>The current Unix timestamp.</returns>
        public static long GetUnixTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Get the current Unix timestamp in milliseconds.
        /// </summary>
        /// <returns>The current Unix timestamp in milliseconds.</returns>
        public static long GetUnixTimestampMilliseconds()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// Get the current time in a specified timezone.
        /// </summary>
        /// <param name="timeZoneId">The timezone to get the current time in.</param>
        /// <returns>The current time in the specified timezone.</returns>
        public static DateTime GetTimeInTimezone(string timeZoneId)
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
        }
    }
}