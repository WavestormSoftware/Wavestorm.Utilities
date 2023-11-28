namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        /// <summary>
        /// Provides methods for getting information about the application.
        /// </summary>
        public static class Time
        {
            /// <summary>
            /// Get the current Unix timestamp.
            /// </summary>
            /// <returns>The current Unix timestamp.</returns>
            public static long GetUnixTimestamp()
            {
                return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            }

            /// <summary>
            /// Get the current Unix timestamp in milliseconds.
            /// </summary>
            /// <returns>The current Unix timestamp in milliseconds.</returns>
            public static long GetUnixTimestampMilliseconds()
            {
                return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }

            /// <summary>
            /// Get the current time in a specified timezone.
            /// </summary>
            /// <param name="timeZoneId">The timezone to get the current time in.</param>
            /// <returns>The current time in the specified timezone.</returns>
            public static DateTime GetTimeInTimezone(string timeZoneId)
            {
                return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
            }
        }
    }
}