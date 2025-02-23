using SingleScope.Common;
using SingleScope.Maui.Controls;

namespace SingleScope.Maui.Dialogs
{
    public interface IDialogService
    {
        Task<bool> ShowConfirmationDialogAsync(string message, string title, string accept = "Ok", string cancel = "Cancel");

        Task<string?> ShowInputPromptAsync(string title, string message, string accept = "Ok", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = default, string initialValue = "");

        Task<string?> ShowActionSheetAsync(string title, string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons);

        Task ShowInfoDialogAsync(string message);

        Task ShowWarningDialogAsync(string message);

        Task ShowErrorDialogAsync(string message);

        void ShowInfoDialog(string message);

        void ShowWarningDialog(string message);

        void ShowErrorDialog(string message);

        IDisposable ShowLoading(string message, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        IDisposingNotificator<ProgressiveLoadingPopup> ShowProgressiveLoading(string message, ProgressiveLoadingProgressType progressType = ProgressiveLoadingProgressType.ActivityIndicator, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        IDisposable ShowFullPageLoading(Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);
    }
}
