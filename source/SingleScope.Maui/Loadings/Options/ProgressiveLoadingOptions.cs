using SingleScope.Maui.Loadings.Core;

namespace SingleScope.Maui.Loadings.Options
{
    public sealed class ProgressiveLoadingOptions : LoadingBaseOptions
    {
        public ProgressiveType Type { get; set; } = ProgressiveType.ActivityIndicator;

        public double InitialProgress { get; set; } = 0;

        public Color? IndicatorColor { get; set; }
    }
}
