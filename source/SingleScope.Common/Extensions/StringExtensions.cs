using System.Text.RegularExpressions;

namespace SingleScope.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToKebabCase(this string origin)
        {
            // Use a regular expression to identify and process parts of the string outside of curly braces
            return Regex.Replace(origin, @"[a-zA-Z]+(?=(?:[^{}]*{[^{}]*})*[^{}]*$)", match =>
            {
                // Convert the matched segment to kebab-case
                return Regex.Replace(match.Value, "([a-z])([A-Z])", "$1-$2").ToLower();
            });
        }

        public static string SanitizeForLogging(this string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return message;
            }

            // Replace newline and carriage return characters
            message = message.Replace("\n", "\\n").Replace("\r", "\\r");

            // Optionally escape additional unsafe characters (e.g., for HTML logs)
            message = System.Web.HttpUtility.HtmlEncode(message);

            return message;
        }
    }
}
