using System.IO.Compression;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Files
    {
        /// <summary>
        /// Provides methods for compressing and decompressing data.
        /// </summary>
        public static class Compression
        {
            /// <summary>
            /// Compress binary data using GZip.
            /// </summary>
            /// <param name="data">The data to compress.</param
            /// <returns>The compressed data.</returns
            public static byte[] Compress(byte[] data)
            {
                try
                {
                    using var memoryStream = new MemoryStream();
                    using var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress);
                    gZipStream.Write(data, 0, data.Length);
                    gZipStream.Close();
                    return memoryStream.ToArray();
                }
                catch (Exception e)
                {
                    return Array.Empty<byte>();
                }
            }

            /// <summary>
            /// Decompress binary data using GZip.
            /// </summary>
            /// <param name="data">The data to decompress.</param
            /// <returns>The decompressed data.</returns
            public static byte[] Decompress(byte[] data)
            {
                try
                {
                    using var memoryStream = new MemoryStream();
                    using var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
                    gZipStream.Write(data, 0, data.Length);
                    gZipStream.Close();
                    return memoryStream.ToArray();
                }
                catch (Exception e)
                {
                    return Array.Empty<byte>();
                }
            }

            /// <summary>
            /// Zips a directory to the specified path.
            /// </summary>
            /// <param name="directory">The directory to zip.</param>
            /// <param name="path">The path to the zip file.</param>
            /// <returns>True if the directory was zipped successfully, false otherwise.</returns>
            public static bool ZipDirectory(string directory, string path)
            {
                try
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(directory, path);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            /// <summary>
            /// Extracts a zip file to the specified directory.
            /// </summary>
            /// <param name="zip">The zip file to extract.</param>
            /// <param name="directory">The directory to extract the zip file to.</param>
            /// <returns>True if the zip file was extracted successfully, false otherwise.</returns>
            public static bool ExtractZip(string zip, string directory)
            {
                try
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zip, directory);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}