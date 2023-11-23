using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.InteropServices;

namespace Wavestorm.Utilities;

public partial class Utilities
{
    public class Services
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
    }
}