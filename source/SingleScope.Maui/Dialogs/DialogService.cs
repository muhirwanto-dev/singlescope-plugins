using CommunityToolkit.Maui.Extensions;
using Microsoft.Extensions.Options;
using SingleScope.Common.Lifetimes;
using SingleScope.Common.Lifetimes.Abstraction;
using SingleScope.Maui.Dialogs.Controls;
using SingleScope.Maui.Dialogs.Enums;
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
#if NET10_0_OR_GREATER
            Task<string?>? displayTask = Application.Current?.Windows[0].Page?.DisplayActionSheetAsync(
#else
            Task<string?>? displayTask = Application.Current?.Windows[0].Page?.DisplayActionSheet(
#endif // NET10_0_OR_GREATER
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
#if NET10_0_OR_GREATER
            Task<bool>? displayTask = Application.Current?.Windows[0].Page?.DisplayAlertAsync(
#else
            Task<bool>? displayTask = Application.Current?.Windows[0].Page?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                title,
                message,
                accept,
                cancel
                );

            return displayTask ?? Task.FromResult(false);
        }

        public Task ShowErrorDialogAsync(string message)
        {
#if NET10_0_OR_GREATER
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.Windows[0].Page?.DisplayAlertAsync(
#else
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.Windows[0].Page?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                "Error",
                message,
                "Ok"
                ));
        }

        public Task ShowInfoDialogAsync(string message)
        {
#if NET10_0_OR_GREATER
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.Windows[0].Page?.DisplayAlertAsync(
#else
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.Windows[0].Page?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                "Info",
                message,
                "Ok"
                ));
        }

        public Task ShowWarningDialogAsync(string message)
        {
#if NET10_0_OR_GREATER
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.Windows[0].Page?.DisplayAlertAsync(
#else
            return MainThread.InvokeOnMainThreadAsync(() => Application.Current?.Windows[0].Page?.DisplayAlert(
#endif // NET10_0_OR_GREATER
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
#if NET10_0_OR_GREATER
            Task<string?>? displayTask = Application.Current?.Windows[0].Page?.DisplayPromptAsync(
#else
            Task<string?>? displayTask = Application.Current?.Windows[0].Page?.DisplayPromptAsync(
#endif // NET10_0_OR_GREATER
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
#if NET10_0_OR_GREATER
            Page page = Application.Current?.Windows[0].Page ?? throw new NullReferenceException("No page available");
#else
            Page page = Application.Current?.Windows[0].Page ?? throw new NullReferenceException("No page available");
#endif // NET10_0_OR_GREATER
            var popup = CreateLoadingPopup(message, cancelAction);

            cancellationTokenSource ??= new CancellationTokenSource();
            bool cancelled = false;

            popup.Closed += (sender, arg) =>
            {
                if (!cancelled)
                {
                    cancelled = true;
                    cancellationTokenSource.Cancel();
                }
            };

            var disposingNotificator = DisposableScope.Create(() =>
            {
                if (!cancelled)
                {
                    popup?.CloseAsync();
                }

                popup = null;
            });

            cancellationTokenSource.Token.Register(disposingNotificator.Dispose);

            MainThread.InvokeOnMainThreadAsync(() => page.ShowPopup(popup));

            return disposingNotificator;
        }

        public IDisposableScope<ProgressiveLoadingPopup> ShowProgressiveLoading(string message, ProgressiveLoadingProgressType progressType = ProgressiveLoadingProgressType.ActivityIndicator, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
        {
            Page page = Application.Current?.Windows[0].Page ?? throw new NullReferenceException("No page available");
            var popup = CreateProgressiveLoadingPopup(message, cancelAction, progressType);

            cancellationTokenSource ??= new CancellationTokenSource();
            bool cancelled = false;

            popup.Closed += (sender, arg) =>
            {
                if (!cancelled)
                {
                    cancelled = true;
                    cancellationTokenSource.Cancel();
                }
            };

            var disposableAction = DisposableScope<ProgressiveLoadingPopup>.Create(
                popup,
                () =>
                {
                    if (!cancelled)
                    {
                        popup?.CloseAsync();
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
