using Microsoft.Extensions.Logging;
using SingleScope.Plugin.Enums;

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

        private PopupHelper()
        {
            _logger = null;
            _pageLoading = new PageLoading();
            _interactiveDialog = new InteractiveDialog();
            _reportMode = PopupReportMode.ReportDialog;
        }

        public PopupHelper SetReportMode(PopupReportMode reportMode)
        {
            _reportMode = reportMode;

            return this;
        }

        public PopupHelper SetLogger(ILogger logger)
        {
            _logger = logger;

            return this;
        }

        public void ReportException(Exception exception, string message, params object?[] args)
        {
            message += "\n---> Original stack trace:\n";
            message += exception.ToString();

            if ((_reportMode & PopupReportMode.ReportLogging) != 0)
            {
                _logger?.LogError(message);
            }

            if ((_reportMode & PopupReportMode.ReportDialog) != 0)
            {
                ShowErrorDialog(args.Any() ? string.Format(message, args) : message);
            }
        }

        public void ShowErrorDialog(string message, string title = "Error")
        {
            _interactiveDialog.ShowAlertDialog(message, title);
        }

        public void ShowInfoDialog(string message, string title = "Info")
        {
            _interactiveDialog.ShowAlertDialog(message, title);
        }

        public Task<bool> ShowConfirmationDialogAsync(string message, string? title = null, string? accept = null, string? cancel = null)
        {
            return _interactiveDialog.ShowConfirmationDialogAsync(message, title, accept, cancel);
        }

        public void ShowLoading(string message, string scope = "")
        {
            _pageLoading.Show(message, scope);
        }

        public void ShowPageLoading(string scope = "")
        {
            _pageLoading.ShowTransparent(scope);
        }

        public void HideLoading(string scope = "")
        {
            _pageLoading.Hide(scope);
        }
    }
}
