namespace Wavestorm.Utilities;

public partial class Utilities
{
    public partial class Wavestorm
    {
        /// <summary>
        /// Provides methods for working with Wavestorm Engine.
        /// </summary>
        public class Studio
        {
            /// <summary>
            /// Get the current development version of Wavestorm Studio.
            /// </summary>
            /// <returns>The current development version of Wavestorm Engine.</returns>
            public static Version GetVersion()
            {
                if (Network.Status.IsConnectedToInternet())
                {
                    var version = Network.Request
                        .GetPlain("https://wavestormgames.net/api/studio/version/version.php").ToString();

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
        }
    }
}