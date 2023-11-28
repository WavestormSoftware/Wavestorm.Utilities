using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Services
    {
        /// <summary>
        /// Provides methods for interacting with Discord.
        /// </summary>
        public static class Discord
        {
            /// <summary>
            /// Send discord specific webhook message.
            /// </summary>
            /// <param name="webhookUrl">The webhook URL.</param>
            /// <param name="username">The username of the webhook.</param>
            /// <param name="avatarUrl">The avatar URL of the webhook.</param>
            /// <param name="content">The content of the message.</param>
            /// <returns>True if the message was sent successfully, false otherwise.</returns>
            [Obsolete("Obsolete")]
            public static bool SendDiscordWebhook(string webhookUrl, [Optional] string username, [Optional] string avatarUrl, string content)
            {
                // TODO: Use HttpClient instead of WebClient.

                username ??= "Undefined";
                avatarUrl ??= "";
                try
                {
                    using var client = new WebClient();
                    var data = new NameValueCollection
                    {
                        ["username"] = username,
                        ["avatar_url"] = avatarUrl,
                        ["content"] = content
                    };
                    client.UploadValues(webhookUrl, data);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            
            /// <summary>
            /// Send a discord message through a discord bot using a discord bot token and making use of the discord API. [UNTESTED]
            /// </summary>
            /// <param name="botToken">The discord bot token.</param>
            /// <param name="channelId">The discord channel ID.</param>
            /// <param name="content">The content of the message.</param>
            /// <returns>True if the message was sent successfully, false otherwise.</returns>
            public static async Task<bool> SendDiscordMessage(string botToken, string channelId, string content)
            {
                if (Network.Status.IsConnectedToInternet())
                {
                    var url = $"https://discord.com/api/v9/channels/{channelId}/messages";
                    using var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botToken);
                    var data = new Dictionary<string, string>
                    {
                        ["content"] = content
                    };
                    var json = JsonSerializer.Serialize(data);
                    var response = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                    return response.IsSuccessStatusCode;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}