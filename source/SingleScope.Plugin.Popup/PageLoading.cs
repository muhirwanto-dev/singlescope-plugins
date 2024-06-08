using SingleScope.Plugin.Core.Enums;
using SingleScope.Plugin.Core.Exceptions.Popup;

namespace SingleScope.Plugin.Popup
{
    internal partial class PageLoading
    {
        /// <summary>
        /// Use loading scope to ignore inner loading function calls
        /// </summary>
        private string? _scope = null;

        public void Show(string message, string scope = "")
        {
            if (_scope != null)
            {
                throw new PageLoadingException(ELoadingExceptionType.ScopeAlreadyExist,
                    string.Format("Found existing scope, current scope ({0}) while requested scope ({1})", _scope, scope));
            }

            _scope = scope;

            Application.Current?.Dispatcher?.Dispatch(() =>
            {
#if ANDROID
                ShowLoadingAndroid(message);
#elif IOS
                throw new NotImplementedException();
#else
                throw new NotSupportedException();
#endif
            });
        }

        public void Hide(string scope = "")
        {
            if (_scope != scope)
            {
                throw new PageLoadingException(ELoadingExceptionType.ScopeNotMatched,
                    string.Format("Scope is not match, current scope ({0}) while requested scope ({1})", _scope, scope));
            }

            _scope = null;

            Application.Current?.Dispatcher?.Dispatch(() =>
            {
#if ANDROID
                HideLoadingAndroid();
#elif IOS
                throw new NotImplementedException();
#else
                throw new NotSupportedException();
#endif
            });
        }
    }
}
