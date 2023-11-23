using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Network
    {
        public static class Request
        {
            /// <summary>
            /// Get plain text from URL
            /// </summary>
            /// <param name="url">The URL to get plain text from.</param>
            /// <returns>The plain text from the URL.</returns>
            public static async Task<string> GetPlain(string url)
            {
                if (Status.IsConnectedToInternet())
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
                if (Status.IsConnectedToInternet())
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
        }
    }
}