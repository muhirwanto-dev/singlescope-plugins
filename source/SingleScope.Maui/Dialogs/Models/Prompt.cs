namespace SingleScope.Maui.Dialogs.Models
{
    public sealed record Prompt(
        string Title,
        string Message,
        string Accept = "Ok",
        string Cancel = "Cancel",
        string? Placeholder = null,
        int MaxLength = -1,
        Keyboard? Keyboard = default,
        string InitialValue = "")
        : Dialog(Title, Message)
    {
        public static Prompt Untitled(string message, string accept = "Ok", string cancel = "Cancel", string? placeholder = null,
            int maxLength = -1, Keyboard? keyboard = default, string initialValue = "")
            => new(string.Empty, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
    }
}
