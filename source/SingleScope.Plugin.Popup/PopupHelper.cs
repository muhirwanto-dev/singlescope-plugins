using Microsoft.Extensions.Logging;
using SingleScope.Plugin.Popup.Loading;

namespace SingleScope.Plugin.Popup
{
    public class PopupHelper
    {
        private static Lazy<PopupHelper> s_instance = new Lazy<PopupHelper>(() => new PopupHelper());

        public static PopupHelper Instance => s_instance.Value;

        private IPopupHelperImpl _impl;

        private PopupHelper()
        {
            _impl = new PopupHelperImpl();
        }

        public PopupHelper SetReportMode(PopupReportMode reportMode)
        {
            _impl.SetReportMode(reportMode);

            return this;
        }

        public PopupHelper SetLogger(ILogger? logger)
        {
            _impl.SetLogger(logger);

            return this;
        }

        public PopupHelper SetLoadingParams(LoadingParam param)
        {
            _impl.SetLoadingParams(param);

            return this;
        }

        public PopupHelper SetLoadingGifAssetUri(string? uri, int? height = null, int? width = null)
        {
            _impl.SetGifAssetUri(uri, height, width);

            return this;
        }

        public void ReportException(Exception exception)
        {
            ReportException(exception, string.Empty);
        }

        public void ReportException(Exception exception, string message, params object?[] args)
        {
            _impl.ReportExceptionAsync(exception, message, args);
        }

        public void ShowErrorDialog(string message, string title = "Error")
        {
            _impl.ShowErrorDialogAsync(message, title);
        }

        public void ShowInfoDialog(string message, string? title = null)
        {
            _impl.ShowInfoDialogAsync(message, title);
        }

        public void ShowWarningDialog(string message, string title = "Warning")
        {
            _impl.ShowWarningDialogAsync(message, title);
        }

        public Task ReportExceptionAsync(Exception exception, string message, params object?[] args)
        {
            return _impl.ReportExceptionAsync(exception, message, args);
        }

        public Task ShowErrorDialogAsync(string message, string title = "Error")
        {
            return _impl.ShowErrorDialogAsync(message, title);
        }

        public Task ShowInfoDialogAsync(string message, string? title = null)
        {
            return _impl.ShowInfoDialogAsync(message, title);
        }

        public Task ShowWarningDialogAsync(string message, string title = "Warning")
        {
            return _impl.ShowWarningDialogAsync(message, title);
        }

        public Task<bool> ShowConfirmationDialogAsync(string message, string title = "Confirmation", string accept = "Yes", string cancel = "No")
        {
            return _impl.ShowConfirmationDialogAsync(message, title, accept, cancel);
        }

        public Task<string?> ShowPromptDialogAsync(string message, string title, string accept = "Ok", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = default, string initialValue = "")
        {
            return _impl.ShowPromptDialogAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
        }

        public Task<string?> ShowActionSheetAsync(string title, string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons)
        {
            return _impl.ShowActionSheetAsync(title, cancel, flowDirection, buttons);
        }

        public void ShowLoading(string message, string? scope = null)
        {
            _impl.ShowLoading(message, scope);
        }

        public void ShowTransparentLoading(string? scope = null)
        {
            _impl.ShowLoading(string.Empty, scope, isTransparent: true);
        }

        public void ShowCancelableLoading(string message, Action onCancel, string? scope = null)
        {
            _impl.ShowCancelableLoading(message, onCancel, scope);
        }

        public void ShowCancelableTransparentLoading(Action onCancel, string? scope = null)
        {
            _impl.ShowCancelableLoading(string.Empty, onCancel, scope, isTransparent: true);
        }

        public void HideLoading(string? scope = null)
        {
            _impl.HideLoading(scope);
        }

        public IScopedLoading ShowScopedLoading(string message)
        {
            return _impl.ShowScopedLoading(message);
        }

        public IScopedLoading ShowTransparentScopedLoading()
        {
            return _impl.ShowScopedLoading(string.Empty, isTransparent: true);
        }
    }
}
