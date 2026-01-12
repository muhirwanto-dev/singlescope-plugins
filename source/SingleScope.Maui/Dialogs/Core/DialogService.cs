using SingleScope.Maui.Dialogs.Abstractions;

namespace SingleScope.Maui.Dialogs.Core
{
    internal class DialogService : IDialogService
    {
        private static Page? CurrentPage => Shell.Current;

        public void Show(DialogRequest request) => _ = ShowAsync(request);

        public async Task<DialogResult> ShowAsync(DialogRequest request)
        {
            ArgumentNullException.ThrowIfNull(CurrentPage, nameof(CurrentPage));

            switch (request.Type)
            {
                case DialogRequestType.Alert:
                {
#if NET10_0_OR_GREATER
                    var displayTask = CurrentPage?.DisplayAlertAsync(
#else
                    var displayTask = CurrentPage?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                        request.Title,
                        request.Message,
                        request.Accept
                        );

                    await (displayTask ?? Task.CompletedTask);
                    bool isConfirmed = displayTask is not null;

                    return new DialogResult(
                        isConfirmed,
                        Action: isConfirmed
                            ? request.Accept
                            : null
                            );
                }
                case DialogRequestType.Confirmation:
                {
#if NET10_0_OR_GREATER
                    var displayTask = CurrentPage?.DisplayAlertAsync(
#else
                    var displayTask = CurrentPage?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                        request.Title,
                        request.Message,
                        request.Accept,
                        request.Cancel
                        );

                    bool isConfirmed = displayTask is not null && await displayTask;

                    return new DialogResult(
                        isConfirmed,
                        Action: isConfirmed
                            ? request.Accept
                            : displayTask is not null
                                ? request.Cancel
                                : null
                                );
                }
                case DialogRequestType.ActionSheet:
                {
#if NET10_0_OR_GREATER
                    var displayTask = CurrentPage?.DisplayActionSheetAsync(
#else
                    var displayTask = CurrentPage?.DisplayActionSheet(
#endif // NET10_0_OR_GREATER
                        request.Title,
                        request.Cancel,
                        null,
                        FlowDirection.MatchParent,
                        request.Actions
                        );

                    string? result = await (displayTask ?? Task.FromResult<string?>(null));

                    return new DialogResult(
                        result is not null,
                        Action: result
                        );
                }
                case DialogRequestType.Prompt:
                {
                    var displayTask = CurrentPage?.DisplayPromptAsync(
                        request.Title,
                        request.Message,
                        request.Accept,
                        request.Cancel,
                        null,
                        -1,
                        null,
                        request.InitialValue
                        );

                    string? result = await (displayTask ?? Task.FromResult<string?>(null));

                    return new DialogResult(
                        result is not null,
                        Text: result
                        );
                }
                default:
                {
                    throw new NotSupportedException($"The dialog request type '{request.Type}' is not supported.");
                }
            }
        }
    }
}
