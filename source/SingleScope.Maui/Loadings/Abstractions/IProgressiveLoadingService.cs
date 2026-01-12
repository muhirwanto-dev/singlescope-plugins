using SingleScope.Common.Lifetimes.Abstraction;

namespace SingleScope.Maui.Loadings.Abstractions
{
    public interface IProgressiveLoadingService
    {
        IDisposableScope<IProgressiveLoadingRenderer> Show(string message, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        void ShowFor(string message, Action<IProgressiveLoadingRenderer, CancellationToken> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);

        Task ShowForAsync(string message, Func<IProgressiveLoadingRenderer, CancellationToken, Task> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default);
    }
}
