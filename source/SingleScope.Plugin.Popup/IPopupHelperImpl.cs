using Microsoft.Extensions.Logging;
using SingleScope.Plugin.Popup.Loading;

namespace SingleScope.Plugin.Popup
{
    public interface IPopupHelperImpl
    {
        void SetReportMode(PopupReportMode reportMode);

        void SetLogger(ILogger? logger);

        void SetLoadingOptions(LoadingOptions options);

        void SetLoadingGifImage(byte[]? buffer, int? height = null, int? width = null);

        void SetLoadingGifImageFromEmbeddedResource<TAssemblySource>(string fileName, int? height = null, int? width = null);

        Task ReportExceptionAsync(Exception exception, string message, params object?[] args);

        Task ShowInfoDialogAsync(string message, string? title = null);

        Task ShowWarningDialogAsync(string message, string title = "Warning");

        Task ShowErrorDialogAsync(string message, string title = "Error");

        Task<bool> ShowConfirmationDialogAsync(string message, string title = "Confirmation", string accept = "Yes", string cancel = "No");

        Task<string?> ShowPromptDialogAsync(string title, string message, string accept = "Ok", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = default, string initialValue = "");

        Task<string?> ShowActionSheetAsync(string title, string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons);

        void ShowLoading(string message, string? scope = null, bool isTransparent = false);

        void ShowCancelableLoading(string message, Action onCancel, string? scope = null, bool isTransparent = false);

        void HideLoading(string? scope = null);

        IScopedLoading ShowScopedLoading(string message, bool isTransparent = false);
    }
}
