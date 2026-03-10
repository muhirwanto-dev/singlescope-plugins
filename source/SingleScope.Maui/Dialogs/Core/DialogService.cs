using SingleScope.Maui.Dialogs.Abstractions;
using SingleScope.Maui.Dialogs.Models;

namespace SingleScope.Maui.Dialogs.Core
{
    internal class DialogService : IDialogService
    {
        private static Page? CurrentPage => Shell.Current;

        public void Show(Dialog dialog) => _ = ShowAsync(dialog);

        public async Task ShowAsync(Dialog dialog)
        {
            ArgumentNullException.ThrowIfNull(CurrentPage, nameof(CurrentPage));

            switch (dialog)
            {
                case Alert alert:
                {
#if NET10_0_OR_GREATER
                    var displayTask = CurrentPage?.DisplayAlertAsync(
#else
                    var displayTask = CurrentPage?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                        alert.Title,
                        alert.Message,
                        alert.Cancel,
                        alert.FlowDirection
                        );

                    await (displayTask ?? Task.CompletedTask);

                    break;
                }
                case Confirmation confirmation:
                {
                    _ = ShowAsync(confirmation);

                    break;
                }
                case ActionSheet actionSheet:
                {
                    _ = ShowAsync(actionSheet);

                    break;
                }
                case Prompt prompt:
                {
                    _ = ShowAsync(prompt);

                    break;
                }
                default:
                {
                    throw new NotSupportedException($"The dialog request type '{dialog.GetType()}' is not supported.");
                }
            }
        }

        public Task<string> ShowAsync(ActionSheet dialog)
        {
#if NET10_0_OR_GREATER
            var displayTask = CurrentPage?.DisplayActionSheetAsync(
#else
            var displayTask = CurrentPage?.DisplayActionSheet(
#endif // NET10_0_OR_GREATER
                dialog.Title,
                dialog.Cancel,
                dialog.Destruction,
                dialog.FlowDirection,
                dialog.Buttons
                );

            return displayTask ?? Task.FromResult(string.Empty);
        }

        public Task<string> ShowAsync(Prompt dialog)
        {
            var displayTask = CurrentPage?.DisplayPromptAsync(
                dialog.Title,
                dialog.Message,
                dialog.Accept,
                dialog.Cancel,
                dialog.Placeholder,
                dialog.MaxLength,
                dialog.Keyboard,
                dialog.InitialValue
                );

            return displayTask ?? Task.FromResult(string.Empty);
        }

        public Task<bool> ShowAsync(Confirmation dialog)
        {
#if NET10_0_OR_GREATER
            var displayTask = CurrentPage?.DisplayAlertAsync(
#else
            var displayTask = CurrentPage?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                dialog.Title,
                dialog.Message,
                dialog.Accept,
                dialog.Cancel,
                dialog.FlowDirection
                );

            return displayTask ?? Task.FromResult(false);
        }
    }
}
