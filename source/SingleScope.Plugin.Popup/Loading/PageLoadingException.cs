namespace SingleScope.Plugin.Popup.Loading
{
    public class PageLoadingException : Exception
    {
        public LoadingExceptionType ExceptionType { get; }

        public PageLoadingException(LoadingExceptionType type, string? message = null)
            : base(message)
        {
            ExceptionType = type;
        }
    }
}
