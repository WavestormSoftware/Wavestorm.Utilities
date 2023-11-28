using System.Runtime.InteropServices;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Files
    {
        /// <summary>
        /// Provides methods for performing operations on files.
        /// </summary>
        public static class Operation
        {
            /// <summary>
            /// Reads a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The contents of the file.</returns>
            public static string? ReadFile(string path)
            {
                try
                {
                    return System.IO.File.ReadAllText(path);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            /// <summary>
            /// Reads a binary file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>The contents of the file.</returns>
            public static byte[] ReadBinaryFile(string path)
            {
                try
                {
                    return System.IO.File.ReadAllBytes(path);
                }
                catch (Exception e)
                {
                    return Array.Empty<byte>();
                }
            }

            /// <summary>
            /// Writes a file to the specified path.
            /// </summary>
            /// <param name="path">The path to the file. If null, the current directory is used.</param>
            /// <param name="contents">The contents of the file.</param>
            /// <returns>True if the file was written successfully, false otherwise.</returns>
            public static bool WriteFile([Optional] string? path, string contents)
            {
                path ??= System.AppDomain.CurrentDomain.BaseDirectory;

                try
                {
                    System.IO.File.WriteAllText(path, contents);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            /// <summary>
            /// Writes a binary file to the specified path.
            /// </summary>
            /// <param name="path">The path to the file. If null, the current directory is used.</param>
            /// <param name="contents">The contents of the file.</param>
            /// <returns>True if the file was written successfully, false otherwise.</returns>
            public static bool WriteBinaryFile([Optional] string? path, byte[] contents)
            {
                path ??= System.AppDomain.CurrentDomain.BaseDirectory;

                try
                {
                    System.IO.File.WriteAllBytes(path, contents);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            /// <summary>
            /// Copies a file from the source path to the destination path.
            /// </summary>
            /// <param name="source">The source path.</param>
            /// <param name="destination">The destination path.</param>
            /// <returns>True if the file was copied successfully, false otherwise.</returns>
            public static bool CopyFile(string source, string destination)
            {
                // TODO: Implement a better and more robust method of copying files.
                try
                {
                    System.IO.File.Copy(source, destination);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            /// <summary>
            /// Moves a file from the source path to the destination path.
            /// </summary>
            /// <param name="source">The source path.</param>
            /// <param name="destination">The destination path.</param>
            /// <returns>True if the file was moved successfully, false otherwise.</returns>
            public static bool MoveFile(string source, string destination)
            {
                // TODO: Implement a better and more robust method of moving files.
                try
                {
                    System.IO.File.Move(source, destination);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            /// <summary>
            /// Moves a directory from the source path to the destination path.
            /// </summary>
            /// <param name="source">The source path.</param>
            /// <param name="destination">The destination path.</param>
            /// <returns>True if the directory was moved successfully, false otherwise.</returns>
            public static bool MoveDirectory(string source, string destination)
            {
                // TODO: Implement a better and more robust method of moving directories.
                try
                {
                    System.IO.Directory.Move(source, destination);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            /// <summary>
            /// Deletes a file from the specified path.
            /// </summary>
            /// <param name="path">The path to the file.</param>
            /// <returns>True if the file was deleted successfully, false otherwise.</returns>
            public static bool DeleteFile(string path)
            {
                try
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            /// <summary>
            /// Deletes a directory from the specified path.
            /// </summary>
            /// <param name="path">The path to the directory.</param>
            /// <returns>True if the directory was deleted successfully, false otherwise.</returns>
            public static bool DeleteDirectory(string path)
            {
                try
                {
                    System.IO.Directory.Delete(path);
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