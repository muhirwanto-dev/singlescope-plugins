namespace SingleScope.Plugin.Popup
{
    internal class InteractiveDialog
    {
        public async Task<bool> ShowConfirmationDialogAsync(string message, string title = "Confirmation", string accept = "Yes", string cancel = "No")
        {
            Task<bool>? displayTask = Application.Current?.MainPage?.DisplayAlert(
                title,
                message,
                accept,
                cancel
                );

            return displayTask != null ? await displayTask : false;
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
