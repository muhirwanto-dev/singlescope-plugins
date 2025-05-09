using SingleScope.Maui.Dialogs;
using SingleScope.Maui.Dialogs.Options;
using SingleScope.Maui.Navigation.Options;
using SingleScope.Maui.Reporting.Options;

namespace SingleScope.Maui
{
    public class SingleScopeBuilderOptions
    {
        public static readonly SingleScopeBuilderOptions Default = new();

        public LoadingOptions LoadingOptions { get; set; } = new();

        public AnimatedLoadingOptions AnimatedLoadingOptions { get; set; } = new();

        public ProgressiveLoadingOptions ProgressiveLoadingOptions { get; set; } = new();

        public ReportingOptions ReportingOptions { get; set; } = new();

        public NavigationOptions NavigationOptions { get; set; } = new();
    }
}
