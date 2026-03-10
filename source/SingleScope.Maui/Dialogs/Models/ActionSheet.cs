namespace SingleScope.Maui.Dialogs.Models
{
    public sealed record ActionSheet(
        string Title,
        string Cancel,
        string Destruction,
        FlowDirection FlowDirection,
        params string[] Buttons) : Dialog(Title, string.Empty);
}
