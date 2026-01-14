namespace SingleScope.Maui.Loadings.Abstractions
{
    public interface ILoadingService
    {
        IDisposable Show(string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        void ShowFor(Action<CancellationToken> action, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        Task ShowForAsync(Func<CancellationToken, Task> action, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);
    }
}
