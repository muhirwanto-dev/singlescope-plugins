using SingleScope.Querying.Execution.Cursor;

namespace SingleScope.Querying.Test.Cursor
{
    public class CursorEncodingTests
    {
        [Fact]
        public void EncodeDecode_Roundtrip_Works()
        {
            var value = DateTime.UtcNow;

            var cursor = CursorEncryption.EncodeCursor(value);
            var decoded = CursorEncryption.DecodeCursor(cursor, typeof(DateTime));

            Assert.Equal(value.ToString("O"), ((DateTime)decoded).ToString("O"));
        }
    }
}
