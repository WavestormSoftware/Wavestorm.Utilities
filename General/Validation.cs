namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        public static class Validation
        {
            /// <summary>
            /// Check if an input is null or empty.
            /// </summary>
            /// <typeparam name="T">The type of input to check.</typeparam>
            /// <param name="input">The input to check.</param>
            /// <returns>True if the input is null or empty, false otherwise.</returns>
            public static bool IsNullOrEmpty<T>(T input)
            {
                if (EqualityComparer<T>.Default.Equals(input, default(T)))
                {
                    return true;
                }

                if (input is string str)
                {
                    return string.IsNullOrEmpty(str);
                }

                if (input is System.Collections.IEnumerable enumerable)
                {
                    // Check if the collection is empty
                    return !enumerable.Cast<object>().Any();
                }

                return false;
            }

            /// <summary>
            /// Check if an input is null or whitespace.
            /// </summary>
            /// <typeparam name="T">The type of input to check.</typeparam>
            /// <param name="input">The input to check.</param>
            /// <returns>True if the input is null or whitespace, false otherwise.</returns>
            public static bool Inlist<T>(T item, params T[] list)
            {
                return list.Contains(item);
            }

            /// <summary>
            /// Check if a string is a valid email address.
            /// </summary>
            /// <param name="email">The string to check.</param>
            /// <returns>True if the string is a valid email address, false otherwise.</returns>
            public static bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            /// <summary>
            /// Check if a string is a valid URL.
            /// </summary>
            /// <param name="url">The string to check.</param>
            /// <returns>True if the string is a valid URL, false otherwise.</returns>
            public static bool IsValidUrl(string url)
            {
                return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                       && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            }
        }
    }
}