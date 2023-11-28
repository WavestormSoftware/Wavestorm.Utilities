using System.Net.NetworkInformation;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Network
    {
        /// <summary>
        /// Provides methods for getting information about the network.
        /// </summary>
        public static class Status
        {
            /// <summary>
            /// Checks if the device is connected to the internet.
            /// </summary>
            /// <returns>True if the device is connected to the internet, false otherwise.</returns>
            public static bool IsConnectedToInternet()
            {
                return NetworkInterface.GetIsNetworkAvailable() && Ping("google.com");
            }

            /// <summary>
            /// Ping a host to check if it is reachable.
            /// </summary>
            /// <param name="host">The host to ping.</param>
            /// <returns>True if the host is reachable, false otherwise.</returns>
            public static bool Ping(string host)
            {
                try
                {
                    Ping ping = new();
                    var reply = ping.Send(host);
                    return reply.Status == IPStatus.Success;
                }
                catch (PingException)
                {
                    return false;
                }
            }

            /// <summary>
            /// Check if an URL has an secure connection.
            /// </summary>
            /// <param name="url">The URL to check.</param>
            /// <returns>True if the URL has a secure connection, false otherwise.</returns>
            public static bool IsSecureConnection(string url)
            {
                try
                {
                    var uri = new Uri(url);
                    return uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
                }
                catch (UriFormatException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}