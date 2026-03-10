namespace SingleScope.Maui.Loadings.Abstractions
{
    public interface IProgressiveLoadingRenderer : ILoadingRenderer
    {
        void UpdateProgress(double value);
    }
}
