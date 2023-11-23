namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        public static class Compression
        {
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
        }
    }
}