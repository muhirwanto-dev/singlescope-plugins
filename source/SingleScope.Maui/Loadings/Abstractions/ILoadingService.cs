namespace SingleScope.Maui.Loadings.Abstractions
{
    public interface ILoadingService
    {
        IDisposable Show(string message, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        void ShowFor(string message, Action<CancellationToken> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        Task ShowForAsync(string message, Func<CancellationToken, Task> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);
    }
}
