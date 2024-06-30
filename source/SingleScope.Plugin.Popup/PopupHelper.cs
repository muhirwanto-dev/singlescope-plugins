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

        private PopupHelper()
        {
            _pageLoading = new PageLoading();
            _interactiveDialog = new InteractiveDialog();
            _reportMode = PopupReportMode.ShowException;
        }

        public PopupHelper SetReportMode(PopupReportMode reportMode)
        {
            _reportMode = reportMode;

            return this;
        }

        public void ReportException(Exception exception, string message, params object?[] args)
        {
            message += "\n---> Original stack trace:\n";
            message += exception.ToString();

            if (_reportMode == PopupReportMode.ShowException)
            {
                ShowErrorDialog(args.Any() ? string.Format(message, args) : message);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void ShowErrorDialog(string message, string? title = null)
        {
            _interactiveDialog.ShowAlertDialog(message, title ?? "Error");
        }

        public void ShowInfoDialog(string message, string? title = null)
        {
            _interactiveDialog.ShowAlertDialog(message, title ?? "Info");
        }

        public Task<bool> ShowConfirmationDialogAsync(string message, string? title = null, string? accept = null, string? cancel = null)
        {
            return _interactiveDialog.ShowConfirmationDialogAsync(message, title, accept, cancel);
        }

        public void ShowLoading(string message, string scope = "")
        {
            _pageLoading.Show(message, scope);
        }

        public void HideLoading(string scope = "")
        {
            _pageLoading.Hide(scope);
        }
    }
}
