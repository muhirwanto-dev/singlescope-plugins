using SingleScope.Common.Lifetimes.Abstraction;

namespace SingleScope.Maui.Loadings.Abstractions
{
    public interface IProgressiveLoadingService
    {
        IAsyncDisposableScope<IProgressiveLoadingRenderer> ShowAsync(string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        IAsyncDisposableScope<IProgressiveLoadingRenderer> ShowAsync(int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        Task ShowForAsync(Func<IProgressiveLoadingRenderer, CancellationToken, Task> action, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        Task ShowForAsync(Func<IProgressiveLoadingRenderer, CancellationToken, Task> action, int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);
    }
}
