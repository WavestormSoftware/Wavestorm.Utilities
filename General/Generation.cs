namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        public static class Generation
        {
            /// <summary>
            /// Get a new UUID (Universally Unique Identifier).
            /// </summary>
            /// <returns>A string representation of a new UUID.</returns>
            public static string GetUUID()
            {
                return System.Guid.NewGuid().ToString();
            }

            /// <summary>
            /// Get a random integer between two values.
            /// </summary>
            /// <param name="min">The minimum value.</param>
            /// <param name="max">The maximum value.</param>
            /// <returns>A random integer between the minimum and maximum values.</returns>
            public static int GetRandomInt(int min, int max)
            {
                return new System.Random().Next(min, max);
            }

            /// <summary>
            /// Get a random string of a specified length.
            /// </summary>
            /// <param name="length">The length of the string.</param>
            /// <param name="useNumbers">Include numbers in the random string.</param>
            /// <param name="useSpecialCharacters">Include special characters in the random string.</param>
            /// <returns>A random string of the specified length.</returns>
            public static string GetRandomString(int length, bool useNumbers = false, bool useSpecialCharacters = false)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                const string charsNumbers = "0123456789";
                const string charsSpecial = "!@#$%^&*()_+";

                var allowedChars = chars;

                if (useNumbers && useSpecialCharacters)
                {
                    allowedChars += charsNumbers + charsSpecial;
                }
                else if (useNumbers)
                {
                    allowedChars += charsNumbers;
                }
                else if (useSpecialCharacters)
                {
                    allowedChars += charsSpecial;
                }

                return new string(Enumerable.Repeat(allowedChars, length)
                    .Select(s => s[new Random().Next(s.Length)]).ToArray());
            }
        }
    }
}