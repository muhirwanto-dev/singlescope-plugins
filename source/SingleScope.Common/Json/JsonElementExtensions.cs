using System.Globalization;
using System.Text.Json;

namespace SingleScope.Common.Json
{
    public static class JsonElementExtensions
    {
        public static T? As<T>(this JsonElement element, JsonSerializerOptions? serializerOptions = null)
        {
            return As<T>(element, serializerOptions);
        }

        public static T? AsNumber<T>(this JsonElement element)
        {
            return AsNumber<T>(element);
        }

        public static string? AsString(this JsonElement element)
        {
            return AsString(element);
        }

        public static bool? AsBoolean(this JsonElement element)
        {
            return AsBoolean(element);
        }

        public static T? As<T>(JsonElement? element, JsonSerializerOptions? serializerOptions = null)
        {
            if (element == null)
            {
                return default;
            }

            var kind = element.Value.ValueKind;
            var raw = element.Value.GetRawText();

            return kind switch
            {
                JsonValueKind.Null => default,
                JsonValueKind.Undefined => default,
                JsonValueKind.Object => serializerOptions == null ? JsonSerializer.Deserialize<T>(raw) : JsonSerializer.Deserialize<T>(raw, serializerOptions),
                JsonValueKind.Array => serializerOptions == null ? JsonSerializer.Deserialize<T>(raw) : JsonSerializer.Deserialize<T>(raw, serializerOptions),
                _ => default
            };
        }

        public static T? AsNumber<T>(JsonElement? element)
        {
            if (element == null)
            {
                return default;
            }

            var kind = element.Value.ValueKind;
            var raw = element.Value.GetRawText();

            return kind switch
            {
                JsonValueKind.Number => (T)Convert.ChangeType(float.Parse(raw, CultureInfo.InvariantCulture), typeof(T)),
                _ => default
            };
        }

        public static string? AsString(JsonElement? element)
        {
            if (element == null)
            {
                return default;
            }

            return element.Value.ValueKind switch
            {
                JsonValueKind.String => element.ToString(),
                _ => null
            };
        }

        public static bool? AsBoolean(JsonElement? element)
        {
            if (element == null)
            {
                return default;
            }

            return element.Value.ValueKind switch
            {
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                _ => null
            };
        }
    }
}
