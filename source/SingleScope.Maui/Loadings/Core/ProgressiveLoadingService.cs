using SingleScope.Common.Lifetimes;
using SingleScope.Common.Lifetimes.Abstraction;
using SingleScope.Maui.Loadings.Abstractions;

namespace SingleScope.Maui.Loadings.Core
{
    internal class ProgressiveLoadingService(
        LoadingFactory _factory
        ) : IProgressiveLoadingService
    {
        public IDisposableScope<IProgressiveLoadingRenderer> Show(string message, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            cancellationTokenSource ??= new CancellationTokenSource();

            var renderer = _factory.CreateProgressive()
                .Cancellable(cancelAction != null)
                .WhenClosed(cancelled =>
                {
                    if (cancelled)
                    {
                        cancellationTokenSource.Cancel();
                    }
                });

            var disposable = DisposableScope<IProgressiveLoadingRenderer>.Create((IProgressiveLoadingRenderer)renderer, () =>
            {
                if (!renderer.IsCancelled)
                {
                    MainThread.InvokeOnMainThreadAsync(renderer.HideAsync);
                }
            });

            cancellationTokenSource.Token.Register(disposable.Dispose);

            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await renderer.ShowAsync(message);
            });

            return disposable;
        }

        public void ShowFor(string message, Action<IProgressiveLoadingRenderer, CancellationToken> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            using var scope = Show(message, cancelAction, cancellationTokenSource);

            ArgumentNullException.ThrowIfNull(cancellationTokenSource, nameof(cancellationTokenSource));

            action(scope.Context, cancellationTokenSource.Token);
        }

        public async Task ShowForAsync(string message, Func<IProgressiveLoadingRenderer, CancellationToken, Task> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            using var scope = Show(message, cancelAction, cancellationTokenSource);

            ArgumentNullException.ThrowIfNull(cancellationTokenSource, nameof(cancellationTokenSource));

            await action(scope.Context, cancellationTokenSource.Token);
        }
    }
}
