using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.Options;
using SingleScope.Maui.Loadings.Abstractions;
using SingleScope.Maui.Loadings.Controls;
using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Loadings.Core
{
    internal class LoadingRenderer(
        IOptions<LoadingOptions> options
        ) : LoadingRendererBase, ILoadingRenderer
    {
        private readonly LoadingOptions _options = options.Value;
        private Popup? _popup;

        public override Task HideAsync() => HideInternalAsync(_popup);

        public override Task ShowAsync(string? message = null)
        {
            _popup = _options.Animation != null
                ? new AnimatedLoadingPopup(_options, message)
                : new LoadingPopup(_options, message);

            return ShowInternalAsync(_options.PageOptions.PageSource, _popup);
        }
    }
}
