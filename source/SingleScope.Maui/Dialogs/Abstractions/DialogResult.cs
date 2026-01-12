namespace SingleScope.Maui.Dialogs.Abstractions
{
    public record DialogResult(bool IsConfirmed, string? Action = null, string? Text = null);
}
