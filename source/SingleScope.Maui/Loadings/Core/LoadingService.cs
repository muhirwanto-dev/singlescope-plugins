using SingleScope.Common.Lifetimes;
using SingleScope.Maui.Loadings.Abstractions;

namespace SingleScope.Maui.Loadings.Core
{
    internal class LoadingService(
        LoadingFactory _factory
        ) : ILoadingService
    {
        public IDisposable Show(string message, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
        {
            cancellationTokenSource ??= new CancellationTokenSource();

            var renderer = _factory.CreateLoading()
                .Cancellable(cancelAction != null)
                .WhenClosed(cancelled =>
                {
                    if (cancelled)
                    {
                        cancellationTokenSource.Cancel();
                    }
                });

            var disposable = DisposableScope.Create(() =>
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

        public void ShowFor(string message, Action<CancellationToken> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
        {
            using var scope = Show(message, cancelAction, cancellationTokenSource);

            ArgumentNullException.ThrowIfNull(cancellationTokenSource, nameof(cancellationTokenSource));

            action(cancellationTokenSource.Token);
        }

        public async Task ShowForAsync(string message, Func<CancellationToken, Task> action, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
        {
            using var scope = Show(message, cancelAction, cancellationTokenSource);

            ArgumentNullException.ThrowIfNull(cancellationTokenSource, nameof(cancellationTokenSource));

            await action(cancellationTokenSource.Token);
        }
    }
}
