using System.Globalization;
using System.Runtime.InteropServices;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class SystemInfo
    {
        public static class OS
        {
            /// <summary>
            /// Gets the name of the operating system running on this computer.
            /// </summary>
            /// <returns>The name of the operating system running on this computer.</returns>
            public static string GetOperatingSystemName()
            {
                return RuntimeInformation.OSDescription;
            }

            /// <summary>
            /// Gets the version of the operating system running on this computer.
            /// </summary>
            /// <returns>The version of the operating system running on this computer.</returns>
            public static string GetOperatingSystemVersion()
            {
                return Environment.OSVersion.VersionString;
            }

            /// <summary>
            /// Gets the architecture of the operating system running on this computer.
            /// </summary>
            /// <returns>The architecture of the operating system running on this computer.</returns>
            public static string GetOperatingSystemArchitecture()
            {
                return RuntimeInformation.OSArchitecture.ToString();
            }

            /// <summary>
            /// Gets the name of the user who is currently logged in.
            /// </summary>
            /// <returns>The name of the user who is currently logged in.</returns>
            public static string GetUserName()
            {
                return Environment.UserName;
            }

            /// <summary>
            /// Gets the name of the computer.
            /// </summary>
            /// <returns>The name of the computer.</returns>
            public static string GetComputerName()
            {
                return Environment.MachineName;
            }

            /// <summary>
            /// Gets the user's language.
            /// </summary>
            /// <returns>The user's language.</returns>
            public static string GetUserLanguage()
            {
                return CultureInfo.CurrentCulture.DisplayName;
            }
        }
    }
}