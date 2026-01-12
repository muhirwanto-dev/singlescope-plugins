using Microsoft.Extensions.Options;
using SingleScope.Maui.Loadings.Abstractions;
using SingleScope.Maui.Loadings.Controls;
using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Loadings.Core
{
    internal class ProgressiveLoadingRenderer(
        IOptions<ProgressiveLoadingOptions> options
        ) : LoadingRendererBase, IProgressiveLoadingRenderer
    {
        private readonly ProgressiveLoadingOptions _options = options.Value;
        private ProgressiveLoadingPopup? _popup;

        public override Task HideAsync() => HideInternalAsync(_popup);

        public override Task ShowAsync(string? message = null)
        {
            _popup = new ProgressiveLoadingPopup(_options, message);

            return ShowInternalAsync(_options.PageOptions.PageSource, _popup);
        }

        public void UpdateProgress(double value)
        {
            if (_popup == null)
            {
                return;
            }

            _popup.ProgressValue = value;
        }
    }
}
