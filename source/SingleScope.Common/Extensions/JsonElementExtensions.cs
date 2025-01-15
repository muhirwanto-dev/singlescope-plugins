using System.Globalization;
using System.Text.Json;

namespace SingleScope.Common.Extensions
{
    public static class JsonElementExtensions
    {
        public static object? GetValueAsObject(this JsonElement element)
        {
            var kind = element.ValueKind;
            var raw = element.GetRawText();

            return kind switch
            {
                JsonValueKind.Number => float.Parse(raw, CultureInfo.InvariantCulture),
                JsonValueKind.String => element.GetString(),
                JsonValueKind.True => element.GetBoolean(),
                JsonValueKind.False => element.GetBoolean(),
                JsonValueKind.Null => null,
                JsonValueKind.Undefined => null,
                JsonValueKind.Object => raw,
                JsonValueKind.Array => raw,
                _ => raw
            };
        }
    }
}
