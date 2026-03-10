using System.Globalization;
using System.Text.Json;

namespace SingleScope.Extensions.Json
{
    public static class JsonElementExtensions
    {
        /// <summary>
        /// Deserializes the specified JSON element to an instance of the specified type.
        /// </summary>
        /// <remarks>This method attempts to deserialize only JSON objects or arrays. If the JSON element
        /// is of another kind, such as a primitive value, an exception is thrown.</remarks>
        /// <typeparam name="T">The type to which to deserialize the JSON element.</typeparam>
        /// <param name="element">The nullable JSON element to deserialize. If null, the method returns the default value for type T.</param>
        /// <param name="serializerOptions">Options to control the behavior during deserialization. If null, default options are used.</param>
        /// <returns>An instance of type T deserialized from the JSON element, or the default value for type T if the element is
        /// null, undefined, or represents a JSON null value.</returns>
        /// <exception cref="InvalidCastException">Thrown if the JSON element does not represent an object or array and cannot be deserialized to type T.</exception>
        public static T? As<T>(this JsonElement? element, JsonSerializerOptions? serializerOptions = null)
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
                JsonValueKind.Object => JsonSerializer.Deserialize<T>(raw, serializerOptions),
                JsonValueKind.Array => JsonSerializer.Deserialize<T>(raw, serializerOptions),
                _ => throw new InvalidCastException($"Cannot deserialize JsonValueKind '{kind}' to type '{typeof(T).FullName}'."),
            };
        }

        public static T? AsNumber<T>(this JsonElement? element)
            where T : struct, IConvertible
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
                JsonValueKind.Null => default,
                _ => throw new InvalidCastException($"{kind}"),
            };
        }

        public static string? AsString(this JsonElement? element)
        {
            if (element == null)
            {
                return default;
            }

            return element.Value.ValueKind switch
            {
                JsonValueKind.String => element.ToString(),
                JsonValueKind.Null => null,
                _ => throw new InvalidCastException($"{element.Value.ValueKind}"),
            };
        }

        public static bool? AsBoolean(this JsonElement? element)
        {
            if (element == null)
            {
                return default;
            }

            return element.Value.ValueKind switch
            {
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.Null => null,
                _ => throw new InvalidCastException($"{element.Value.ValueKind}"),
            };
        }

        public static bool TryAs<T>(
            this JsonElement? element,
            out T? value,
            JsonSerializerOptions? serializerOptions = null)
        {
            value = default;

            if (element == null)
            {
                return false;
            }

            var kind = element.Value.ValueKind;
            if (kind is not (JsonValueKind.Object or JsonValueKind.Array))
            {
                return false;
            }

            try
            {
                value = JsonSerializer.Deserialize<T>(
                    element.Value.GetRawText(),
                    serializerOptions);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryAsNumber<T>(
            this JsonElement? element,
            out T? value)
            where T : struct, IConvertible
        {
            value = default;

            if (element == null || (
                element.Value.ValueKind != JsonValueKind.Number &&
                element.Value.ValueKind != JsonValueKind.Null))
            {
                return false;
            }

            try
            {
                if (element.Value.TryGetDecimal(out var decimalValue))
                {
                    value = (T)Convert.ChangeType(
                        decimalValue,
                        typeof(T),
                        CultureInfo.InvariantCulture);

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryAsString(
            this JsonElement? element,
            out string? value)
        {
            value = null;

            if (element == null)
            {
                return false;
            }

            if (element.Value.ValueKind == JsonValueKind.String)
            {
                value = element.Value.GetString();
                return true;
            }

            if (element.Value.ValueKind == JsonValueKind.Null)
            {
                return true;
            }

            return false;
        }

        public static bool TryAsBoolean(
            this JsonElement? element,
            out bool? value)
        {
            value = null;

            if (element == null)
            {
                return false;
            }

            return element.Value.ValueKind switch
            {
                JsonValueKind.True => (value = true) is not null,
                JsonValueKind.False => (value = false) is not null,
                JsonValueKind.Null => true,
                _ => false,
            };
        }
    }
}
