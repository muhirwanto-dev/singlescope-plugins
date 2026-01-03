using System.Text;

namespace SingleScope.Querying.Execution.Cursor
{
    public sealed class CursorEncodingOptions
    {
        public CursorEncodingOptions()
        {
        }

        public CursorEncodingOptions(Encoding encoding)
        {
            Encoding = encoding;
        }

        public Encoding Encoding { get; } = Encoding.UTF8;
    }
}
