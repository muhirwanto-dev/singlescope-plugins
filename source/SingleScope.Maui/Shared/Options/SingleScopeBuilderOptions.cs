using SingleScope.Maui.Dialogs.Options;
using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Shared.Options
{
    public class SingleScopeBuilderOptions
    {
        public static readonly SingleScopeBuilderOptions Default = new();

        public DialogOptions DialogOptions { get; set; } = new();

        public LoadingOptions LoadingOptions { get; set; } = new();

        public ProgressiveLoadingOptions ProgressiveLoadingOptions { get; set; } = new();
    }
}
