using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.Options;
using SingleScope.Common;
using SingleScope.Maui.Dialogs.Controls;
using SingleScope.Maui.Dialogs.Options;

namespace SingleScope.Maui.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly LoadingOptions _loadingOptions;
        private readonly ProgressiveLoadingOptions _progressiveLoadingOptions;

        public DialogService(IOptions<LoadingOptions> options, IOptions<ProgressiveLoadingOptions> progressiveLoadingOptions)
        {
            _loadingOptions = options.Value;
            _progressiveLoadingOptions = progressiveLoadingOptions.Value;
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

        public void ShowInfoDialog(string message)
        {
            _ = ShowInfoDialogAsync(message);
        }

        public void ShowWarningDialog(string message)
        {
            _ = ShowWarningDialogAsync(message);
        }

        public void ShowErrorDialog(string message)
        {
            _ = ShowErrorDialogAsync(message);
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

        public IDisposable ShowLoading(string message, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
        {
            Page page = Application.Current?.MainPage ?? throw new NullReferenceException("No page available");
            var popup = CreateLoadingPopup(message, cancelAction);

            cancellationTokenSource ??= new CancellationTokenSource();
            bool cancelled = false;

            popup.Closed += (sender, arg) =>
            {
                if (arg.WasDismissedByTappingOutsideOfPopup && !cancelled)
                {
                    cancelled = true;
                    cancellationTokenSource.Cancel();
                }
            };

            var disposingNotificator = ValueDisposable.Create(() =>
            {
                if (!cancelled)
                {
                    popup?.Close();
                }

                popup = null;
            });

            cancellationTokenSource.Token.Register(disposingNotificator.Dispose);

            MainThread.InvokeOnMainThreadAsync(() => page.ShowPopup(popup));

            return disposingNotificator;
        }

        public IValueDisposable<ProgressiveLoadingPopup> ShowProgressiveLoading(string message, ProgressiveLoadingProgressType progressType = ProgressiveLoadingProgressType.ActivityIndicator, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
        {
            Page page = Application.Current?.MainPage ?? throw new NullReferenceException("No page available");
            var popup = CreateProgressiveLoadingPopup(message, cancelAction, progressType);

            cancellationTokenSource ??= new CancellationTokenSource();
            bool cancelled = false;

            popup.Closed += (sender, arg) =>
            {
                if (arg.WasDismissedByTappingOutsideOfPopup && !cancelled)
                {
                    cancelled = true;
                    cancellationTokenSource.Cancel();
                }
            };

            var disposableAction = ValueDisposable<ProgressiveLoadingPopup>.Create(
                popup,
                () =>
                {
                    if (!cancelled)
                    {
                        popup?.Close();
                    }

                    popup = null;
                });

            cancellationTokenSource.Token.Register(disposableAction.Dispose);

            MainThread.InvokeOnMainThreadAsync(() => page.ShowPopup(popup));

            return disposableAction;
        }

        public IDisposable ShowFullPageLoading(Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
        {
            return ShowLoading(string.Empty, cancelAction, cancellationTokenSource);
        }

        protected virtual LoadingPopup CreateLoadingPopup(string message, Action? cancelAction)
        {
            return new LoadingPopup
            {
                Options = new AnimatedLoadingOptions
                {
                    PopupPadding = _loadingOptions.PopupPadding,
                    BackgroundColor = string.IsNullOrEmpty(message) ? Colors.Transparent : _loadingOptions.BackgroundColor,
                    CornerRadius = _loadingOptions.CornerRadius,
                    Message = message,
                    MinimumHeight = _loadingOptions.MinimumHeight,
                    MinimumWidth = _loadingOptions.MinimumWidth,
                },
                CanBeDismissedByTappingOutsideOfPopup = cancelAction != null,
            };
        }

        protected virtual ProgressiveLoadingPopup CreateProgressiveLoadingPopup(string message, Action? cancelAction, ProgressiveLoadingProgressType progressType)
        {
            return new ProgressiveLoadingPopup
            {
                Options = new ProgressiveLoadingOptions
                {
                    PopupPadding = _progressiveLoadingOptions.PopupPadding,
                    BackgroundColor = string.IsNullOrEmpty(message) ? Colors.Transparent : _progressiveLoadingOptions.BackgroundColor,
                    CornerRadius = _progressiveLoadingOptions.CornerRadius,
                    Message = message,
                    MinimumHeight = _progressiveLoadingOptions.MinimumHeight,
                    MinimumWidth = _progressiveLoadingOptions.MinimumWidth,
                    ProgressType = progressType,
                    IndicatorColor = _progressiveLoadingOptions.IndicatorColor,
                },
                CanBeDismissedByTappingOutsideOfPopup = cancelAction != null,
            };
        }
    }
}
