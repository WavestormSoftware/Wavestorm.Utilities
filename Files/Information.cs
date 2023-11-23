using System.Security.Cryptography;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Files
    {
        public static class Information
        {
            /// <summary>
            /// Gets the size of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The size of the file in bytes.</returns>
            public static long GetFileSize(string path)
            {
                try
                {
                    return new System.IO.FileInfo(path).Length;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }

            /// <summary>
            /// Gets the creation time of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The creation time of the file.</returns>
            public static DateTime GetFileCreationTime(string path)
            {
                try
                {
                    return new System.IO.FileInfo(path).CreationTime;
                }
                catch (Exception e)
                {
                    return DateTime.MinValue;
                }
            }

            /// <summary>
            /// Gets the last access time of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The last access time of the file.</returns>
            public static DateTime GetFileLastAccessTime(string path)
            {
                try
                {
                    return new System.IO.FileInfo(path).LastAccessTime;
                }
                catch (Exception e)
                {
                    return DateTime.MinValue;
                }
            }

            /// <summary>
            /// Gets the last write time of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The last write time of the file.</returns>
            public static DateTime GetFileLastWriteTime(string path)
            {
                try
                {
                    return new System.IO.FileInfo(path).LastWriteTime;
                }
                catch (Exception e)
                {
                    return DateTime.MinValue;
                }
            }

            /// <summary>
            /// Get the MD5 hash of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The MD5 hash of the file.</returns>
            public static string GetFileMd5(string path)
            {
                try
                {
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            byte[] hashBytes = md5.ComputeHash(stream);
                            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                        }
                    }
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
    }
}