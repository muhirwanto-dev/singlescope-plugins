using SingleScope.Maui.Dialogs.Core;

namespace SingleScope.Maui.Dialogs.Abstractions
{
    public record DialogRequest(
        string Title,
        string Message,
        DialogRequestType Type,
        string? Accept = null,
        string? Cancel = null,
        string[]? Actions = null,
        string? InitialValue = null
    )
    {
        public static DialogRequest Prompt(string title, string message, string initialValue = "", string accept = "Ok", string cancel = "Cancel")
            => new(
                Title: title,
                Message: message,
                Type: DialogRequestType.Prompt,
                Accept: accept,
                Cancel: cancel,
                InitialValue: initialValue
            );

        public static DialogRequest ActionSheet(string title, string[] actions, string cancel = "Cancel")
            => new(
                Title: title,
                Message: string.Empty,
                Type: DialogRequestType.ActionSheet,
                Actions: actions,
                Cancel: cancel
            );

        public static DialogRequest Confirmation(string title, string message, string accept = "Ok", string cancel = "Cancel")
            => new(
                Title: title,
                Message: message,
                Type: DialogRequestType.Confirmation,
                Accept: accept,
                Cancel: cancel
            );

        public static DialogRequest Alert(string title, string message, string accept = "Ok", string cancel = "Cancel")
            => new(
                Title: title,
                Message: message,
                Type: DialogRequestType.Alert,
                Accept: accept,
                Cancel: cancel
            );

        public static DialogRequest Info(string message, string accept = "Ok")
            => new(
                Title: "Info",
                Message: message,
                Type: DialogRequestType.Alert,
                Accept: accept
            );

        public static DialogRequest Warning(string message, string accept = "Ok")
            => new(
                Title: "Warning",
                Message: message,
                Type: DialogRequestType.Alert,
                Accept: accept
            );

        public static DialogRequest Error(string message, string accept = "Ok")
            => new(
                Title: "Error",
                Message: message,
                Type: DialogRequestType.Alert,
                Accept: accept
            );
    }
}
