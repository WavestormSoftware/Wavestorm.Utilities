using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

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
        /// Get plain text from URL
        /// </summary>
        /// <param name="url">The URL to get plain text from.</param>
        /// <returns>The plain text from the URL.</returns>
        public static async Task<string> GetPlain(string url)
        {
            if (IsConnectedToInternet())
            {
                using var httpClient = new HttpClient();
                try
                {
                    var response = await httpClient.GetStringAsync(url);
                    return response;
                }
                catch (HttpRequestException ex)
                {
                    return $"Error fetching plain text: {ex.Message}";
                }
            }
            else
            {
                return "No internet connection. Cannot get plain text.";
            }
        }
        
        /// <summary>
        /// Download a file from an URL and return it as a byte array.
        /// </summary>
        /// <param name="url">The URL to download the file from.</param>
        /// <returns>The downloaded file.</returns>
        public static async Task<byte[]> GetBinary(string url)
        {
            if (IsConnectedToInternet())
            {
                using var httpClient = new HttpClient();
                try
                {
                    var response = await httpClient.GetByteArrayAsync(url);
                    return response;
                }
                catch (HttpRequestException ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Download a file from an URL.
        /// </summary>
        /// <param name="url">The URL to download the file from.</param>
        /// <param name="path">The path to save the file to.</param>
        /// <returns>True if the file was downloaded successfully, false otherwise.</returns>
        public static async Task<bool> DownloadFileAsync(string url, [Optional] string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    // If path is not specified, use the application directory
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(url));
                }

                using (var httpClient = new HttpClient())
                using (var response = await httpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();

                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = File.Create(path))
                    {
                        await contentStream.CopyToAsync(fileStream);
                    }

                    return true;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Post JSON data to an URL. 
        /// </summary>
        /// <param name="url">The URL to post the JSON data to.</param>
        /// <param name="data">The JSON data to post.</param>
        /// <returns>The response from the URL.</returns>
        public static object PostJson(string url, object data)
        {
            try
            {
                using var httpClient = new HttpClient();
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(url, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Retrieves a base domain name from a full domain name. 
        /// </summary>
        /// <param name="domainName">Dns Domain name as a string</param>
        /// <returns>Base domain name</returns>
        public static string GetBaseDomain(string domainName)
        {
            var vars = domainName.Split('.');
            if (vars == null || vars.Length != 3)
            {
                return domainName;
            }
            var dom  = new List<string>(vars);
            var remove = vars.Length - 2;
            dom.RemoveRange(0, remove);
            return dom[0] + "." + dom[1]; ;                                
        }
    }
}