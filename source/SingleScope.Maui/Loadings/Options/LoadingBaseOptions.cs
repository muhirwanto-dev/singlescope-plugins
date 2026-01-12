using SingleScope.Maui.Shared.Options;

namespace SingleScope.Maui.Loadings.Options
{
    public abstract class LoadingBaseOptions
    {
        public PageOptions PageOptions { get; set; } = new();

        public Thickness Padding { get; set; } = new(16);

        public double CornerRadius { get; set; } = 12;

        public Color PanelColor { get; set; } = Colors.White.WithAlpha(0.6f);

        public double MinimumWidth { get; set; } = 196;

        public double MinimumHeight { get; set; } = 196;
    }
}
