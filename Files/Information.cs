using System.Security.Cryptography;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Files
    {
        /// <summary>
        /// Provides methods for getting information about files.
        /// </summary>
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
            
            #region Extra
            /// <summary>
            /// Get the SHA1 hash of a file from the specified path. 
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The SHA1 hash of the file.</returns>
            public static string GetFileSha1(string path)
            {
                try
                {
                    using (var sha1 = SHA1.Create())
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            byte[] hashBytes = sha1.ComputeHash(stream);
                            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                        }
                    }
                }
                catch (Exception e)
                {
                    return "";
                }
            }
            
            /// <summary>
            /// Get the SHA256 hash of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The SHA256 hash of the file.</returns>
            public static string GetFileSha256(string path)
            {
                try
                {
                    using (var sha256 = SHA256.Create())
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            byte[] hashBytes = sha256.ComputeHash(stream);
                            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                        }
                    }
                }
                catch (Exception e)
                {
                    return "";
                }
            }
            
            /// <summary>
            /// Get the SHA384 hash of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The SHA384 hash of the file.</returns>
            public static string GetFileSha384(string path)
            {
                try
                {
                    using (var sha384 = SHA384.Create())
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            byte[] hashBytes = sha384.ComputeHash(stream);
                            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                        }
                    }
                }
                catch (Exception e)
                {
                    return "";
                }
            }
            
            /// <summary>
            /// Get the SHA512 hash of a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The SHA512 hash of the file.</returns>
            public static string GetFileSha512(string path)
            {
                try
                {
                    using (var sha512 = SHA512.Create())
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            byte[] hashBytes = sha512.ComputeHash(stream);
                            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                        }
                    }
                }
                catch (Exception e)
                {
                    return "";
                }
            }
            #endregion Extra
        }
    }
}