namespace SingleScope.Plugin.Popup.Dialog
{
    internal class InteractiveDialog
    {
        public Task<bool> ShowConfirmationDialogAsync(string message, string title, string accept, string cancel)
        {
            Task<bool>? displayTask = Application.Current?.MainPage?.DisplayAlert(
                title,
                message,
                accept,
                cancel
                );

            return displayTask ?? Task.FromResult(false);
        }

        public Task<string?> ShowPromptDialogAsync(string title, string message, string accept, string cancel, string? placeholder, int maxLength, Keyboard? keyboard, string initialValue)
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

        public void ShowAlertDialog(string message, string title, string confirm = "Ok")
        {
            Application.Current?.Dispatcher?.Dispatch(() =>
            {
                Application.Current.MainPage?.DisplayAlert(title, message, confirm);
            });
        }
    }
}
