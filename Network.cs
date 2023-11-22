using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.NetworkInformation;

namespace Wavestorm.Utilities;

public partial class Utilities
{
    public class Network
    {
        /// <summary>
        /// Checks if the device is connected to the internet.
        /// </summary>
        /// <returns>True if the device is connected to the internet, false otherwise.</returns>
        public static bool IsConnectedToInternet()
        {
            return NetworkInterface.GetIsNetworkAvailable() && PingHost("google.com");
        }

        /// <summary>
        /// Ping a host to check if it is reachable.
        /// </summary>
        /// <param name="host">The host to ping.</param>
        /// <returns>True if the host is reachable, false otherwise.</returns>
        public static bool PingHost(string host)
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

        /// <summary>
        /// Get the public IP address of the device.
        /// </summary>
        /// <returns>The public IP address of the device.</returns>
        public static async Task<string> GetPublicIpAddress()
        {
            if (IsConnectedToInternet())
            {
                const string url = "https://api.ipify.org";

                using var httpClient = new HttpClient();
                try
                {
                    var response = await httpClient.GetStringAsync(url);
                    return response;
                }
                catch (HttpRequestException ex)
                {
                    return $"Error fetching public IP address: {ex.Message}";
                }
            }
            else
            {
                return "No internet connection. Cannot get public IP address.";
            }
        }

        /// <summary>
        /// Check if a port is open.
        /// </summary>
        /// <param name="port">The port to check.</param>
        /// <returns>True if the port is open, false otherwise.</returns>
        public static bool IsPortOpen(int port)
        {
            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (var tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// This method has not been implemented yet.
        /// </summary>
        public static void DownloadFile(string url, string path)
        {
            // TODO: Implement
        }
    }
}