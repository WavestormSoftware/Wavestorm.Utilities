using System.Reflection;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        public static class Application
        {
            /// <summary>
            /// Gets the name of the application.
            /// </summary>
            /// <returns>The name of the application.</returns>
            public static string GetApplicationName()
            {
                return AppDomain.CurrentDomain.FriendlyName;
            }

            /// <summary>
            /// Gets the version of the application.
            /// </summary>
            /// <returns>The version of the application.</returns>
            public static string GetApplicationVersion()
            {
                return Assembly.GetEntryAssembly()?.GetName().Version.ToString();
            }
        }
    }
}