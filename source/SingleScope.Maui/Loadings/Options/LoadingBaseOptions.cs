using SingleScope.Maui.Shared.Options;

namespace SingleScope.Maui.Loadings.Options
{
    public abstract class LoadingBaseOptions
    {
        public PageOptions PageOptions { get; set; } = new();

        public Thickness Padding { get; set; } = new(8);

        public double CornerRadius { get; set; } = 12;

        public Color PanelColor { get; set; } = Colors.Black.WithAlpha(0.6f);

        public double MinimumWidth { get; set; } = 120;

        public double MinimumHeight { get; set; } = 120;
    }
}
