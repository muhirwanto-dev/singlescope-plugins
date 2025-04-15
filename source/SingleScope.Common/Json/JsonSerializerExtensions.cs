using System.Text.Json;

namespace SingleScope.Common.Json
{
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
