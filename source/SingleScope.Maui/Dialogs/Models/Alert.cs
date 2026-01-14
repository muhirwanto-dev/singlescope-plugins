using SingleScope.Maui.Dialogs.Models;

namespace SingleScope.Maui.Dialogs
{
    public sealed record Alert(
        string Title,
        string Message,
        string Cancel = "Ok",
        FlowDirection FlowDirection = FlowDirection.MatchParent
        ) : Dialog(Title, Message)
    {
        public static Alert Untitled(string message, string cancel = "Ok", FlowDirection flowDirection = FlowDirection.MatchParent)
            => new(string.Empty, message, cancel, flowDirection);

        public static Alert Info(string message, string cancel = "Ok", FlowDirection flowDirection = FlowDirection.MatchParent)
            => new("Info", message, cancel, flowDirection);

        public static Alert Warning(string message, string cancel = "Ok", FlowDirection flowDirection = FlowDirection.MatchParent)
            => new("Warning", message, cancel, flowDirection);

        public static Alert Error(string message, string cancel = "Ok", FlowDirection flowDirection = FlowDirection.MatchParent)
            => new("Error", message, cancel, flowDirection);
    }
}
