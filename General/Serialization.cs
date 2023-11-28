namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        /// <summary>
        /// Provides methods for serializing and deserializing data.
        /// </summary>
        public static class Serialization
        {
            /// <summary>
            /// Serialize an object to a JSON string.
            /// </summary>
            /// <param name="obj">The object to serialize.</param>
            /// <returns>A JSON string representation of the object.</returns>
            public static string SerializeObject(object obj)
            {
                return System.Text.Json.JsonSerializer.Serialize(obj);
            }

            /// <summary>
            /// Deserialize a JSON string to an object.
            /// </summary>
            /// <param name="json">The JSON string to deserialize.</param>
            /// <returns>An object representation of the JSON string.</returns>
            public static object DeserializeObject(string json)
            {
                return System.Text.Json.JsonSerializer.Deserialize<object>(json);
            }
        }
    }
}