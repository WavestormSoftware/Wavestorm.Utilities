using System.Text;

namespace Wavestorm.Utilities;

public partial class Utilities
{
    public class Logging
    {
        public class Error
        {
            /// <summary>
            /// Logs an error message to a file located in the user's documents folder.
            /// </summary>
            /// <param name="message">The message to log.</param>
            /// <param name="exception">The exception to log.</param>
            /// <param name="file">The file to log to.</param>
            /// <param name="append">Whether to append to the file or overwrite it.</param>
            /// <param name="includeStackTrace">Whether to include the stack trace in the log.</param>
            /// <param name="includeTimestamp">Whether to include the timestamp in the log.</param>
            /// <returns>Whether the log was successful.</returns>
            public static bool Log(string message, Exception exception, string file = "error.log", bool append = true,
                bool includeStackTrace = true, bool includeTimestamp = true)
            {
                // Get the path to the user's documents folder.
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var fullPath = Path.Combine(path, file);

                // Create the log message.
                var logMessage = new StringBuilder();
                if (includeTimestamp)
                {
                    logMessage.Append($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ");
                }

                logMessage.Append($"ERROR: {message}");
                if (includeStackTrace)
                {
                    logMessage.Append($"\n{exception.StackTrace}");
                }

                // Write the log message to the file.
                try
                {
                    using var writer = new StreamWriter(fullPath, append);
                    writer.WriteLine(logMessage.ToString());
                    writer.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}