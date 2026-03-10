namespace SingleScope.Maui.Loadings.Abstractions
{
    public interface ILoadingRenderer
    {
        Task ShowAsync(string? message = null);

        Task HideAsync();

        ILoadingRenderer WhenClosed(Action<bool> onClosed);

        ILoadingRenderer Cancellable(bool enable);

        bool IsCancelled { get; }
    }
}
