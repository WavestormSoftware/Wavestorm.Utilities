using System.Reflection;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        /// <summary>
        ///  Provides methods for getting information about the application.
        /// </summary>
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
            public static string? GetApplicationVersion()
            {
                return Assembly.GetEntryAssembly()?.GetName().Version?.ToString();
            }
            
            /// <summary>
            /// Gets the name of the company that produced the application.
            /// </summary>
            /// <returns>The name of the company that produced the application.</returns>
            public static string? GetCompanyName()
            {
                return Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
            }
            
            /// <summary>
            /// Gets the description of the application.
            /// </summary>
            /// <returns>The description of the application.</returns>
            public static string? GetDescription()
            {
                return Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
            }
            
            /// <summary>
            /// Gets the product name of the application.
            /// </summary>
            /// <returns>The product name of the application.</returns>
            public static string? GetProductName()
            {
                return Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            }
            
            /// <summary>
            /// Gets the title of the application.
            /// </summary>
            /// <returns>The title of the application.</returns>
            public static string? GetTitle()
            {
                return Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
            }
            
            /// <summary>
            /// Gets the trademark of the application.
            /// </summary>
            /// <returns>The trademark of the application.</returns>
            public static string? GetTrademark()
            {
                return Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyTrademarkAttribute>()?.Trademark;
            }
        }
    }
}