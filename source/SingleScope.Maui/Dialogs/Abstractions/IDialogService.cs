using SingleScope.Maui.Dialogs.Models;

namespace SingleScope.Maui.Dialogs.Abstractions
{
    public interface IDialogService
    {
        void Show(Dialog dialog);

        Task ShowAsync(Dialog dialog);

        Task<string> ShowAsync(ActionSheet dialog);

        Task<string> ShowAsync(Prompt dialog);

        Task<bool> ShowAsync(Confirmation dialog);
    }
}
