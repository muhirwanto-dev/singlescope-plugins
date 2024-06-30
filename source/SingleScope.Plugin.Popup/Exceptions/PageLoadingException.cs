using SingleScope.Plugin.Enums;

namespace SingleScope.Plugin.Exceptions
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
