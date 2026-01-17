namespace SingleScope.Maui.Loadings.Abstractions
{
    public interface ILoadingService
    {
        IAsyncDisposable ShowAsync(string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        IAsyncDisposable ShowAsync(int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        Task ShowForAsync(Func<CancellationToken, Task> action, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        Task ShowForAsync(Func<CancellationToken, Task> action, int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);
    }
}
