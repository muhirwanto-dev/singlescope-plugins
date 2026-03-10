namespace SingleScope.Querying.Paging
{
    public sealed class CursorPaginationOptions
    {
        /// <summary>
        /// Opaque cursor value (consumer-defined encoding).
        /// </summary>
        public string? Cursor { get; }

        /// <summary>
        /// Field used for cursor comparison (must match sorting).
        /// </summary>
        public string CursorField { get; }

        public int Limit { get; }

        public CursorDirection Direction { get; }

        public CursorPaginationOptions(
            string cursorField,
            string? cursor = null,
            int limit = 20,
            CursorDirection direction = CursorDirection.Forward)
        {
            CursorField = cursorField;
            Cursor = cursor;
            Limit = limit;
            Direction = direction;
        }
    }
}
