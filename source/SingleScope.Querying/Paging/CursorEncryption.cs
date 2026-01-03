using System;
using System.Globalization;
using System.Text;

namespace SingleScope.Querying.Paging
{
    public class CursorEncryption
    {
        public static string EncodeCursor(object value)
            => Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                    Convert.ToString(value, CultureInfo.InvariantCulture)!));

        public static object DecodeCursor(string cursor, Type targetType)
            => Convert.ChangeType(
                Encoding.UTF8.GetString(
                    Convert.FromBase64String(cursor)), targetType, CultureInfo.InvariantCulture)!;
    }
}
