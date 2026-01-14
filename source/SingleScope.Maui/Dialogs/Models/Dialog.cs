namespace SingleScope.Maui.Dialogs.Models
{
    public abstract record Dialog(
        string Title,
        string Message
        )
    {
        public static Alert Alert(string title, string message, string cancel = "Ok", FlowDirection flowDirection = FlowDirection.MatchParent)
            => new(title, message, cancel, flowDirection);

        public static Confirmation Confirmation(string title, string message, string accept = "Ok", string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent)
            => new(title, message, accept, cancel, flowDirection);

        public static Prompt Prompt(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = default, string initialValue = "")
            => new(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);

        public static ActionSheet ActionSheet(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
            => new(title, cancel, destruction, flowDirection, buttons);

        public static ActionSheet ActionSheet(string title, string cancel, params string[] buttons)
            => new(title, cancel, string.Empty, FlowDirection.MatchParent, buttons);
    }
}
