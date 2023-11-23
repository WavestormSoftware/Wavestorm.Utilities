namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        public static class Manipulation
        {
            /// <summary>
            /// Convert a string to a byte array.
            /// </summary>
            /// <param name="str">The string to convert.</param>
            /// <returns>A byte array representation of the string.</returns>
            public static byte[] StringToByteArray(string str)
            {
                return System.Text.Encoding.UTF8.GetBytes(str);
            }

            /// <summary>
            /// Convert a byte array to a string.
            /// </summary>
            /// <param name="bytes">The byte array to convert.</param>
            /// <returns>A string representation of the byte array.</returns>
            public static string ByteArrayToString(byte[] bytes)
            {
                return System.Text.Encoding.UTF8.GetString(bytes);
            }

            /// <summary>
            /// Trims a sub string from a string at the start of the string.
            /// </summary>
            /// <param name="text">The string to trim.</param>
            /// <param name="textToTrim">The sub string to trim from the string.</param>
            /// <param name="caseInsensitive">Whether or not to trim the sub string case insensitive.</param>
            public static string TrimStart(string text, string textToTrim, bool caseInsensitive)
            {
                while (true)
                {
                    var match = text[..textToTrim.Length];

                    if (match == textToTrim ||
                        (caseInsensitive &&
                         string.Equals(match, textToTrim, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (text.Length <= match.Length)
                            text = "";
                        else
                            text = text.Substring(textToTrim.Length);
                    }
                    else
                        break;
                }

                return text;
            }
        }
    }
}