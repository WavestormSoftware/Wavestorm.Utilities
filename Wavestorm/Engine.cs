using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Wavestorm.Utilities;

public partial class Utilities
{
    public partial class Wavestorm
    {
        public class Engine
        {
            /// <summary>
            /// Get the current development version of Wavestorm Engine.
            /// </summary>
            /// <returns>The current development version of Wavestorm Engine.</returns>
            public static Version GetVersion()
            {
                if (Network.Status.IsConnectedToInternet())
                {
                    var version = Network.Request
                        .GetPlain("https://wavestormgames.net/api/engine/version/version.php")
                        .ToString();

                    if (version == null)
                    {
                        return new Version(0, 0, 0, 0);
                    }
                    else
                    {
                        return new Version(version);
                    }
                }
                else
                {
                    return new Version(0, 0, 0, 0);
                }
            }

            /// <summary>
            /// Download the latest version of Wavestorm Engine. This will download the latest version of Wavestorm Engine (zip file) and extract it to the specified directory.
            /// </summary>
            /// <param name="directory">The directory to extract the latest version of Wavestorm Engine to.</param>
            /// <returns>True if the latest version of Wavestorm Engine was downloaded and extracted successfully, false otherwise.</returns>
            public static bool Download([Optional] string directory)
            {
                try
                {
                    directory ??= AppDomain.CurrentDomain.BaseDirectory;

                    if (!Network.Status.IsConnectedToInternet())
                    {
                        // No internet connection available.
                        return false;
                    }

                    var version = Network.Request
                        .GetPlain("https://wavestormgames.net/api/engine/version/version.php")
                        ?.ToString();

                    if (version == null)
                    {
                        // Failed to retrieve Wavestorm Engine version.
                        return false;
                    }

                    var zipFilePath = Path.Combine(directory, "wse.zip");
                    var downloadSuccess = Network.Request
                        .DownloadFileAsync($"https://wavestormgames.net/api/engine/download.php?version={version}",
                            zipFilePath).Result;

                    if (!downloadSuccess)
                    {
                        // Failed to download Wavestorm Engine.
                        return false;
                    }

                    if (Utilities.Files.Compression.ExtractZip(zipFilePath, directory))
                    {
                        if (Utilities.Files.Operation.DeleteFile(zipFilePath))
                        {
                            // Wavestorm Engine downloaded and extracted successfully.
                            return true;
                        }
                        else
                        {
                            // Failed to delete temporary zip file.
                            return false;
                        }
                    }
                    else
                    {
                        // Failed to extract Wavestorm Engine.
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            /// <summary>
            /// Compile a Wavestorm Engine project.
            /// </summary>
            /// <param name="enginePath">The path to the Wavestorm Engine executable.</param>
            /// <param name="projectPath">The path to the Wavestorm project file.</param>
            /// <param name="version">The version of Wavestorm Engine to use.</param>
            /// <param name="output">The path to save the compiled project to.</param>
            /// <returns>True if the project was compiled successfully, false otherwise.</returns>
            public static bool Compile(string enginePath, string projectPath, [Optional] Version version, string output)
            {
                try
                {
                    var engineExecutable = enginePath;

                    if (!enginePath.Contains("wavestorm-engine.exe"))
                    {
                        engineExecutable = Directory
                            .GetFiles(enginePath, "wavestorm-engine.exe", SearchOption.AllDirectories).FirstOrDefault();

                        if (engineExecutable == null)
                        {
                            // Wavestorm engine executable not found.
                            return false;
                        }
                    }

                    if (!projectPath.Contains(".wse"))
                    {
                        var projectFile = Directory.GetFiles(projectPath, "*.wse", SearchOption.AllDirectories)
                            .FirstOrDefault();

                        if (projectFile == null)
                        {
                            // Wavestorm project file not found.
                            return false;
                        }

                        projectPath = projectFile;
                    }

                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = engineExecutable;
                        process.StartInfo.Arguments = $"-p \"{projectPath}\" -o \"{output}\"";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;

                        process.Start();

                        process.WaitForExit();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            /// <summary>
            /// Fetch Wavestorm Engine account information. (JSON)
            /// </summary>
            /// <param name="username">The username of the account.</param>
            /// <param name="apiKey">The API key of the account.</param>
            /// <returns>The account information of the specified account.</returns>
            public static string FetchAccount(string username, string apiKey)
            {
                try
                {
                    var account = Network.Request
                        .GetPlain(
                            $"https://wavestormgames.net/api/engine/account/fetch.php?username={username}&api_key={apiKey}")
                        ?.ToString();

                    if (account == null)
                    {
                        return null;
                    }
                    else
                    {
                        return account;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            /// <summary>
            /// Upload a Wavestorm Engine project to the Wavestorm Engine cloud.
            /// </summary>
            /// <param name="username">The username of the account.</param>
            /// <param name="apiKey">The API key of the account.</param>
            /// <param name="projectPath">The path to the Wavestorm project file.</param>
            /// <param name="version">The version of Wavestorm Engine to use.</param>
            /// <returns>True if the project was uploaded successfully, false otherwise.</returns>
            public static bool Upload(string username, string apiKey, string projectPath, [Optional] Version version)
            {
                // TODO: Implement.
                return false;
            }
        }
    }
}