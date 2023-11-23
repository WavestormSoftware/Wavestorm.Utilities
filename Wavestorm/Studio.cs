namespace Wavestorm.Utilities.Wavestorm;

public partial class Wavestorm
{
    public class Studio
    {
        /// <summary>
        /// Get the current development version of Wavestorm Studio.
        /// </summary>
        /// <returns>The current development version of Wavestorm Engine.</returns>
        public static Version GetVersion()
        {
            if (Utilities.Network.IsConnectedToInternet())
            {
                var version = Utilities.Network.GetPlain("https://wavestormgames.net/api/studio/version/version.php").ToString();

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