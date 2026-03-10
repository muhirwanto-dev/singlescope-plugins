using System.Text.Json;

namespace SingleScope.Extensions.Json
{
    public class WebJsonSerializerOptions
    {
        /// <summary>
        /// Gets a preconfigured instance of JsonSerializerOptions with settings optimized for web scenarios.
        /// </summary>
        /// <remarks>The returned options instance uses the Web defaults, including camel-cased property
        /// names, case-insensitive property matching, and ignores null values when writing JSON. It is suitable for
        /// most web API serialization and deserialization tasks. Modifying the returned instance does not affect future
        /// calls to this property.</remarks>
        public static JsonSerializerOptions Default => new(JsonSerializerDefaults.Web)
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            UnknownTypeHandling = System.Text.Json.Serialization.JsonUnknownTypeHandling.JsonElement,
        };

        /// <summary>
        /// Gets a preconfigured set of <see cref="JsonSerializerOptions"/> for web scenarios that formats JSON output
        /// with indentation for improved readability.
        /// </summary>
        /// <remarks>The returned options use the <see cref="JsonSerializerDefaults.Web"/> settings,
        /// ignore properties with null values when serializing, handle unknown types as <see
        /// cref="System.Text.Json.JsonElement"/>, and enable indented (pretty-printed) JSON output. These options are
        /// suitable for scenarios where human-readable JSON is preferred, such as logging or configuration
        /// files.</remarks>
        public static JsonSerializerOptions Indented => new(JsonSerializerDefaults.Web)
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            UnknownTypeHandling = System.Text.Json.Serialization.JsonUnknownTypeHandling.JsonElement,
            WriteIndented = true,
        };

        /// <summary>
        /// Creates a new instance of <see cref="JsonSerializerOptions"/> preconfigured with settings optimized for web
        /// scenarios.
        /// 
        /// </summary>
        /// <remarks>The returned options use the <see cref="JsonSerializerDefaults.Web"/> preset, which
        /// includes settings such as camel-cased property names, case-insensitive property matching, and relaxed JSON
        /// escaping. These defaults are intended to align with common web API conventions.</remarks>
        /// <returns>A <see cref="JsonSerializerOptions"/> instance configured with default options suitable for web-based JSON
        /// serialization and deserialization.</returns>
        public static JsonSerializerOptions Create() => new(JsonSerializerDefaults.Web);
    }
}
