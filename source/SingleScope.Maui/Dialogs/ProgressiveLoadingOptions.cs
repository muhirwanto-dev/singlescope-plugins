namespace SingleScope.Maui.Dialogs
{
    public class ProgressiveLoadingOptions : LoadingOptions
    {
        public ProgressiveLoadingProgressType ProgressType { get; set; } = ProgressiveLoadingProgressType.ActivityIndicator;

        public Color? IndicatorColor { get; set; }
    }
}
