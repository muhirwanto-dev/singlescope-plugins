using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SingleScope.Common.Extensions
{
    public static class StringExtensions
    {
        [return: NotNullIfNotNull(nameof(origin))]
        public static string? ToKebabCase(this string? origin)
        {
            if (string.IsNullOrEmpty(origin))
            {
                return origin;
            }

            // Use a regular expression to identify and process parts of the string outside of curly braces
            return Regex.Replace(origin, @"[a-zA-Z]+(?=(?:[^{}]*{[^{}]*})*[^{}]*$)",
                match => Regex.Replace(match.Value, "([a-z])([A-Z])", "$1-$2").ToLower());
        }

        [return: NotNullIfNotNull(nameof(message))]
        public static string? Sanitize(this string? message)
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

        public static SecureString? ToSecureString(this string? origin)
        {
            if (string.IsNullOrWhiteSpace(origin))
            {
                return null;
            }

            var secured = new SecureString();

            foreach (char c in origin.ToCharArray())
            {
                secured.AppendChar(c);
            }

            return secured;
        }

        public static string FillSide(this string? str, string character, int lenght, string prefix, string postfix)
        {
            CalculateAvailablePositions(str, lenght, prefix, postfix, out int leftCount, out int rightCount);

            var builder = new StringBuilder(str);

            builder.Insert(0, character, leftCount);
            builder.Insert(0, prefix);
            builder.Append(character[0], rightCount);
            builder.Append(postfix);

            return builder.ToString();
        }

        public static string FillRight(this string? str, string character, int lenght, string postfix = "")
        {
            CalculateAvailablePositions(str, lenght, "", postfix, out _, out int rightCount, useLeft: false);

            var builder = new StringBuilder(str);

            builder.Append(character[0], rightCount);
            builder.Append(postfix);

            return builder.ToString();
        }

        public static string FillLeft(this string? str, string character, int lenght, string prefix = "")
        {
            CalculateAvailablePositions(str, lenght, prefix, "", out int leftCount, out _, useRight: false);

            var builder = new StringBuilder(str);

            builder.Insert(0, character, leftCount);
            builder.Insert(0, prefix);

            return builder.ToString();
        }

        private static void CalculateAvailablePositions(this string? str, int finalLength, string prefix, string postfix,
            out int leftCount, out int rightCount, bool useLeft = true, bool useRight = true)
        {
            int prepostLength = prefix.Length + postfix.Length;
            int mergedLength = (str?.Length ?? 0) + prepostLength;
            int charRemaining = finalLength - mergedLength;

            leftCount = rightCount = 0;

            if (charRemaining > 0)
            {
                if (useLeft && useRight)
                {
                    int mod = charRemaining % 2;
                    if (mod == 0)
                    {
                        leftCount = rightCount = charRemaining /= 2;
                    }
                    else
                    {
                        leftCount = (charRemaining - mod) / 2;
                        rightCount = charRemaining - leftCount;
                    }
                }
                else if (useLeft)
                {
                    leftCount = charRemaining;
                }
                else if (useRight)
                {
                    rightCount = charRemaining;
                }
            }
        }
    }
}
