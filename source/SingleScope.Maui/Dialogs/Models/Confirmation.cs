namespace SingleScope.Maui.Dialogs.Models
{
    public sealed record Confirmation(
        string Title,
        string Message,
        string Accept = "Ok",
        string Cancel = "Cancel",
        FlowDirection FlowDirection = FlowDirection.MatchParent
        ) : Dialog(Title, Message)
    {
        public static Confirmation Untitled(string message, string accept = "Ok", string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent)
            => new(string.Empty, message, accept, cancel, flowDirection);
    }
}
