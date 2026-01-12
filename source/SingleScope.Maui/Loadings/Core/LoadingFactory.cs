using SingleScope.Maui.Loadings.Abstractions;

namespace SingleScope.Maui.Loadings.Core
{
    internal class LoadingFactory(
        Func<ILoadingRenderer> _loadingRenderer,
        Func<IProgressiveLoadingRenderer> _progressiveRenderer)
    {
        public ILoadingRenderer CreateLoading() => _loadingRenderer();

        public IProgressiveLoadingRenderer CreateProgressive() => _progressiveRenderer();
    }
}
