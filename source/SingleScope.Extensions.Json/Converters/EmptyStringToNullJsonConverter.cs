using System.Text.Json;
using System.Text.Json.Serialization;

namespace SingleScope.Extensions.Json.Converters
{
    /// <summary>
    /// Converts empty JSON string values to null when deserializing, and serializes values using the default behavior
    /// for the specified type.
    /// </summary>
    /// <remarks>This converter is useful when working with APIs or data sources that represent missing or
    /// null values as empty strings in JSON. When deserializing, if the JSON value is an empty string, the converter
    /// returns null for reference types or the default value for value types. When serializing, the converter uses the
    /// default serialization behavior for the type.</remarks>
    /// <typeparam name="T">The type of object to convert.</typeparam>
    public class EmptyStringToNullJsonConverter<T> : JsonConverter<T>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // If the value is an empty string, return null
            if (reader.TokenType == JsonTokenType.String && string.IsNullOrEmpty(reader.GetString()))
            {
                return default;
            }

            // Otherwise, deserialize the value normally
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
