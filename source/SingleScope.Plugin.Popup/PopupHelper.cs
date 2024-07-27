using Microsoft.Extensions.Logging;
using SingleScope.Plugin.Core;
using SingleScope.Plugin.Popup.Dialog;
using SingleScope.Plugin.Popup.Loading;

namespace SingleScope.Plugin.Popup
{
    public class PopupHelper
    {
        private static Lazy<PopupHelper> s_instance = new Lazy<PopupHelper>(() => new PopupHelper());

        public static PopupHelper Instance => s_instance.Value;

        private PageLoading _pageLoading;
        private InteractiveDialog _interactiveDialog;
        private PopupReportMode _reportMode;
        private ILogger? _logger;

        private byte[]? _gifImage = null;

        private PopupHelper()
        {
            _logger = null;
            _pageLoading = new PageLoading();
            _interactiveDialog = new InteractiveDialog();
            _reportMode = PopupReportMode.LogAndFullException;
        }

        public PopupHelper SetReportMode(PopupReportMode reportMode)
        {
            _reportMode = reportMode;

            return this;
        }

        public PopupHelper SetLogger(ILogger? logger)
        {
            _logger = logger;

            return this;
        }

        public PopupHelper SetGifLoadingBytes(byte[]? image)
        {
            _gifImage = image;
            _pageLoading.SetGifImage(image);

            return this;
        }

        public PopupHelper SetGifLoadingEmbeddedResource<TAssemblySource>(string filename)
        {
            var loader = new ImageLoader<TAssemblySource>();
            byte[]? buffer = loader.GetByteArrayFromEmbeddedResource(filename);

            _gifImage = buffer;
            _pageLoading.SetGifImage(buffer);

            return this;
        }

        public void ReportException(Exception exception)
        {
            ReportException(exception, string.Empty);
        }

        public void ReportException(Exception exception, string message, params object?[] args)
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

                ShowErrorDialog(args.Any() ? string.Format(message, args) : message);
            }
        }

        public void ShowErrorDialog(string message, string title = "Error")
        {
            if ((_reportMode & PopupReportMode.LogEnable) != 0)
            {
                _logger?.LogError(message);
            }

            _interactiveDialog.ShowAlertDialog(message, title);
        }

        public void ShowInfoDialog(string message, string title = "Info")
        {
            if ((_reportMode & PopupReportMode.LogEnable) != 0)
            {
                _logger?.LogDebug(message);
            }

            _interactiveDialog.ShowAlertDialog(message, title);
        }

        public Task<bool> ShowConfirmationDialogAsync(string message, string title = "Confirmation", string accept = "Yes", string cancel = "No")
        {
            return _interactiveDialog.ShowConfirmationDialogAsync(message, title, accept, cancel);
        }

        public void ShowLoading(string message, string? scope = null)
        {
            _pageLoading.Show(message, scope);
        }

        public void ShowTransparentPageLoading(string? scope = null)
        {
            _pageLoading.ShowTransparent(scope);
        }

        public void HideLoading(string? scope = null)
        {
            _pageLoading.Hide(scope);
        }

        public IScopedLoading ShowScopedLoading(string message)
        {
            var loading = new ScopedLoading();
            loading.SetGifImage(_gifImage);

            return loading.Show(message);
        }

        public IScopedLoading ShowTransparentScopedLoading()
        {
            var loading = new ScopedLoading();
            loading.SetGifImage(_gifImage);

            return loading.ShowTransparent();
        }
    }
}
