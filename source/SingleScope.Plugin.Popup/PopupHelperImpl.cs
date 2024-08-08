using Microsoft.Extensions.Logging;
using SingleScope.Plugin.Core;
using SingleScope.Plugin.Popup.Loading;

namespace SingleScope.Plugin.Popup
{
    internal class PopupHelperImpl : IPopupHelperImpl
    {
        private PageLoading _pageLoading;
        private PopupReportMode _reportMode;
        private ILogger? _logger;

        internal PopupHelperImpl()
        {
            _logger = null;
            _pageLoading = new PageLoading();
            _reportMode = PopupReportMode.LogAndFullException;
        }

        public void SetLoadingOptions(LoadingOptions options)
        {
            _pageLoading.SetLoadingOptions(options);
        }

        public void SetLoadingGifImage(byte[]? buffer, int? height = null, int? width = null)
        {
            _pageLoading.SetGifImage(buffer, height, width);
        }

        public void SetLoadingGifImageFromEmbeddedResource<TAssemblySource>(string fileName, int? height = null, int? width = null)
        {
            var loader = new ImageLoader<TAssemblySource>();
            byte[]? buffer = loader.GetByteArrayFromEmbeddedResource(fileName);

            _pageLoading.SetGifImage(buffer, height, width);
        }

        public void SetLogger(ILogger? logger)
        {
            _logger = logger;
        }

        public void SetReportMode(PopupReportMode reportMode)
        {
            _reportMode = reportMode;
        }

        public Task ReportExceptionAsync(Exception exception, string message, params object?[] args)
        {
            if (!string.IsNullOrEmpty(message))
            {
                message += "\n---> Original stack trace:\n";
            }

            string exStr = exception.ToString();

            if ((_reportMode & (PopupReportMode.ShowExceptionMessage | PopupReportMode.ShowFullException)) != 0)
            {
                if ((_reportMode & PopupReportMode.ShowExceptionMessage) != 0)
                {
                    message += exception.Message;
                }
                else if ((_reportMode & PopupReportMode.ShowFullException) != 0)
                {
                    message += exStr;
                }

                return ShowErrorDialogAsync(args.Any() ? string.Format(message, args) : message);
            }

            return Task.CompletedTask;
        }

        public Task<bool> ShowConfirmationDialogAsync(string message, string title = "Confirmation", string accept = "Yes", string cancel = "No")
        {
            Task<bool>? displayTask = Application.Current?.MainPage?.DisplayAlert(
                title,
                message,
                accept,
                cancel
                );

            return displayTask ?? Task.FromResult(false);
        }

        public Task<string?> ShowActionSheetAsync(string title, string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons)
        {
            Task<string?>? displayTask = Application.Current?.MainPage?.DisplayActionSheet(
                title,
                cancel,
                destruction: null,
                flowDirection,
                buttons: buttons
                );

            return displayTask ?? Task.FromResult<string?>(null);
        }

        public Task<string?> ShowPromptDialogAsync(string title, string message, string accept = "Ok", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "")
        {
            Task<string?>? displayTask = Application.Current?.MainPage?.DisplayPromptAsync(
                title,
                message,
                accept,
                cancel,
                placeholder,
                maxLength,
                keyboard,
                initialValue
                );

            return displayTask ?? Task.FromResult<string?>(null);
        }

        public Task ShowInfoDialogAsync(string message, string? title = null)
        {
            if ((_reportMode & PopupReportMode.LogEnable) != 0)
            {
                _logger?.LogDebug(message);
            }

            return Application.Current!.MainPage!.DisplayAlert(title, message, "Ok");
        }

        public Task ShowWarningDialogAsync(string message, string title = "Warning")
        {
            if ((_reportMode & PopupReportMode.LogEnable) != 0)
            {
                _logger?.LogWarning(message);
            }

            return Application.Current!.MainPage!.DisplayAlert(title, message, "Ok");
        }

        public Task ShowErrorDialogAsync(string message, string title = "Error")
        {
            if ((_reportMode & PopupReportMode.LogEnable) != 0)
            {
                _logger?.LogError(message);
            }

            return Application.Current!.MainPage!.DisplayAlert(title, message, "Ok");
        }

        public void ShowLoading(string message, string? scope = null, bool isTransparent = false)
        {
            if (isTransparent)
            {
                _pageLoading.ShowTransparent(scope);
            }
            else
            {
                _pageLoading.Show(message, scope);
            }
        }

        public void ShowCancelableLoading(string message, Action onCancel, string? scope = null, bool isTransparent = false)
        {
            if (isTransparent)
            {
                _pageLoading.ShowTransparent(scope, isCancelable: true, onCancel);
            }
            else
            {
                _pageLoading.Show(message, scope, isCancelable: true, onCancel);
            }
        }

        public void HideLoading(string? scope = null)
        {
            _pageLoading.Hide(scope);
        }

        public IScopedLoading ShowScopedLoading(string message, bool isTransparent = false)
        {
            var loading = new ScopedLoading();
            loading.SetGifImage(_pageLoading.GifImage);

            if (isTransparent)
            {
                loading.ShowTransparent();
            }
            else
            {
                loading.Show(message);
            }

            return loading;
        }
    }
}
