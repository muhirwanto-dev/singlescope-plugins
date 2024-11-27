using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.Options;
using SingleScope.Core;
using SingleScope.Maui.Controls;

namespace SingleScope.Maui.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly LoadingOptions _loadingOptions;

        public DialogService(IOptions<LoadingOptions> options)
        {
            _loadingOptions = options.Value;
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

        public Task<bool> ShowConfirmationDialogAsync(string message, string title, string accept = "Ok", string cancel = "Cancel")
        {
            Task<bool>? displayTask = Application.Current?.MainPage?.DisplayAlert(
                title,
                message,
                accept,
                cancel
                );

            return displayTask ?? Task.FromResult(false);
        }

        public Task ShowErrorDialogAsync(string message)
        {
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.MainPage?.DisplayAlert(
                "Error",
                message,
                "Ok"
                ));
        }

        public Task ShowInfoDialogAsync(string message)
        {
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.MainPage?.DisplayAlert(
                "Info",
                message,
                "Ok"
                ));
        }

        public Task ShowWarningDialogAsync(string message)
        {
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.MainPage?.DisplayAlert(
                "Warning",
                message,
                "Ok"
                ));
        }

        public Task<string?> ShowInputPromptAsync(string title, string message, string accept = "Ok", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "")
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

        public IDisposable ShowLoading(string message, Action? cancelAction = null, CancellationTokenSource? tokenSource = default)
        {
            Page page = Application.Current?.MainPage ?? throw new NullReferenceException("No page available");
            var popup = CreateLoadingPopup(message, cancelAction);

            tokenSource ??= new CancellationTokenSource();
            bool cancelled = false;

            popup.Closed += (sender, arg) =>
            {
                if (arg.WasDismissedByTappingOutsideOfPopup && !cancelled)
                {
                    cancelled = true;
                    tokenSource.Cancel();
                }
            };

            var disposableAction = new DisposableAction(() =>
            {
                if (!cancelled)
                {
                    popup?.Close();
                }

                popup = null;
            });

            tokenSource.Token.Register(disposableAction.Dispose);

            MainThread.InvokeOnMainThreadAsync(() => page.ShowPopup(popup));

            return disposableAction;
        }

        public IDisposable ShowFullPageLoading(Action? cancelAction = null, CancellationTokenSource? tokenSource = default)
        {
            return ShowLoading(string.Empty, cancelAction, tokenSource);
        }

        protected virtual LoadingPopup CreateLoadingPopup(string message, Action? cancelAction)
        {
            return new LoadingPopup
            {
                Param = new AnimatedLoadingOptions
                {
                    BackgroundColor = string.IsNullOrEmpty(message) ? Colors.Transparent : _loadingOptions.BackgroundColor,
                    CornerRadius = _loadingOptions.CornerRadius,
                    Message = message,
                    MinimumHeight = _loadingOptions.MinimumHeight,
                    MinimumWidth = _loadingOptions.MinimumWidth,
                },
                CanBeDismissedByTappingOutsideOfPopup = cancelAction != null,
            };
        }
    }
}
