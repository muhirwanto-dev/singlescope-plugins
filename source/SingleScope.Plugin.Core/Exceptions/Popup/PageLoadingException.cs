using SingleScope.Plugin.Core.Enums;

namespace SingleScope.Plugin.Core.Exceptions.Popup
{
    public class PageLoadingException : Exception
    {
        public ELoadingExceptionType ExceptionType { get; }

        public PageLoadingException(ELoadingExceptionType type, string? message = null)
            : base(message)
        {
            ExceptionType = type;
        }
    }
}
