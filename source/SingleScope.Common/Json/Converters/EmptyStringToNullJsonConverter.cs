using System.Text.Json;
using System.Text.Json.Serialization;

namespace SingleScope.Common.Json.Converters
{
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
