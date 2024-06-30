using SingleScope.Plugin.Enums;
using SingleScope.Plugin.Exceptions;

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
                throw new PageLoadingException(LoadingExceptionType.ScopeAlreadyExist,
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
                throw new PageLoadingException(LoadingExceptionType.ScopeNotMatched,
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
