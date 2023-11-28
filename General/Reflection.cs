namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class General
    {
        /// <summary>
        /// Provides methods for getting information about the application.
        /// </summary>
        public static class Reflection
        {
            /// <summary>
            /// Get the value of a property from an object.
            /// </summary>
            /// <param name="obj">The object to get the property value from.</param>
            /// <param name="propertyName">The name of the property to get the value of.</param>
            /// <returns>The value of the property.</returns>
            public static object GetPropertyValue(object obj, string propertyName)
            {
                return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
            }

            /// <summary>
            /// Set the value of a property on an object.
            /// </summary>
            /// <param name="obj">The object to set the property value on.</param>
            /// <param name="propertyName">The name of the property to set the value of.</param>
            /// <param name="value">The value to set the property to.</param>
            /// <returns>True if the property was set, false otherwise.</returns>
            public static bool SetPropertyValue(object obj, string propertyName, object value)
            {
                var propertyInfo = obj.GetType().GetProperty(propertyName);
                if (propertyInfo == null)
                {
                    return false;
                }

                propertyInfo.SetValue(obj, value, null);
                return true;
            }

            /// <summary>
            /// Get the value of a field from an object.
            /// </summary>
            /// <param name="obj">The object to get the field value from.</param>
            /// <param name="fieldName">The name of the field to get the value of.</param
            /// <returns>The value of the field.</returns>
            public static object GetFieldValue(object obj, string fieldName)
            {
                return obj.GetType().GetField(fieldName)?.GetValue(obj);
            }

            /// <summary>
            /// Set the value of a field on an object.
            /// </summary>
            /// <param name="obj">The object to set the field value on.</param>
            /// <param name="fieldName">The name of the field to set the value of.</param>
            /// <param name="value">The value to set the field to.</param>
            /// <returns>True if the field was set, false otherwise.</returns>
            public static bool SetFieldValue(object obj, string fieldName, object value)
            {
                var fieldInfo = obj.GetType().GetField(fieldName);
                if (fieldInfo == null)
                {
                    return false;
                }

                fieldInfo.SetValue(obj, value);
                return true;
            }
        }
    }
}