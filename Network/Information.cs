using System.Net.NetworkInformation;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Network
    {
        public static class Information
        {
            /// <summary>
            /// Get the public IP address of the device.
            /// </summary>
            /// <returns>The public IP address of the device.</returns>
            public static async Task<string> GetPublicIpAddress()
            {
                if (Status.IsConnectedToInternet())
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
        }
    }
}