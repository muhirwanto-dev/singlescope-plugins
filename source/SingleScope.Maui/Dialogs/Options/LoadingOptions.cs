namespace SingleScope.Maui.Dialogs.Options
{
    public class LoadingOptions
    {
        public Thickness PopupPadding { get; set; } = 10;

        public Color? BackgroundColor { get; set; }

        public float? CornerRadius { get; set; }

        public double MinimumHeight { get; set; } = 240;

        public double MinimumWidth { get; set; } = 240;

        public string? Message { get; set; }
    }
}
