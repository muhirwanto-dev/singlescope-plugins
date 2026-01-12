namespace SingleScope.Maui.Dialogs.Abstractions
{
    public interface IDialogService
    {
        void Show(DialogRequest request);

        Task<DialogResult> ShowAsync(DialogRequest request);
    }
}
