using System.Text.Json;

namespace SingleScope.Extensions.Json
{
    /// <summary>
    /// Provides extension methods for safely deserializing JSON strings using System.Text.Json.
    /// </summary>
    /// <remarks>These methods enable callers to attempt deserialization of JSON content without throwing
    /// exceptions on failure. Instead, they return a Boolean value indicating success or failure, and output the
    /// deserialized result if successful.</remarks>
    public static class JsonSerializerExtensions
    {
        public static bool TryDeserialize<T>(string? source, out T? result)
        {
            return TryDeserialize<T>(source, null, out result);
        }

        public static bool TryDeserialize<T>(string? source, JsonSerializerOptions? options, out T? result)
        {
            result = default;

            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            try
            {
                result = JsonSerializer.Deserialize<T>(source, options);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
