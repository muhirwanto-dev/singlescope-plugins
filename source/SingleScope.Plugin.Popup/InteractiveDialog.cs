namespace SingleScope.Plugin.Popup
{
    internal class InteractiveDialog
    {
        public async Task<bool> ShowConfirmationDialogAsync(string message, string? title = null, string? accept = null, string? cancel = null)
        {
            Task<bool>? displayTask = Application.Current?.MainPage?.DisplayAlert(
                title ?? "Info",
                message,
                accept ?? "Yes",
                cancel ?? "No"
                );

            return displayTask != null ? await displayTask : false;
        }

        public void ShowAlertDialog(string message, string title, string? confirm = null)
        {
            Application.Current?.Dispatcher?.Dispatch(() =>
            {
                Application.Current.MainPage?.DisplayAlert(title, message, confirm ?? "Ok");
            });
        }
    }
}
