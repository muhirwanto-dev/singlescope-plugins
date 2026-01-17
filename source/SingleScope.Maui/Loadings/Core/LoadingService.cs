using System.Diagnostics;
using Microsoft.Extensions.Options;
using SingleScope.Common.Lifetimes;
using SingleScope.Maui.Loadings.Abstractions;
using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Loadings.Core
{
    internal class LoadingService(
        IOptions<LoadingOptions> _options,
        IServiceProvider _provider
        ) : ILoadingService
    {
        private readonly Stopwatch _stopwatch = new();

        public IAsyncDisposable ShowAsync(string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
            => ShowAsync(_options.Value.MinimumTimeframeMs, message, cancelAction, cancellationTokenSource);

        public IAsyncDisposable ShowAsync(int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            cancellationTokenSource ??= new CancellationTokenSource();

            var renderer = CreateRenderer(cancelAction, cancellationTokenSource);
            var disposable = AsyncDisposableScope.Create(async () =>
            {
                if (!renderer.IsCancelled)
                {
                    while (_stopwatch.ElapsedMilliseconds <= loadingTimeMs)
                    { }

                    // fix: popup scrim will never fade if the interval between ShowAsync() and HideAsync() is too short
                    await Task.Delay(_options.Value.MinimumTimeframeMs);
                    await renderer.HideAsync();
                }
            });

            cancellationTokenSource.Token.Register(async () => await disposable.DisposeAsync());
            renderer.ShowAsync(message).ConfigureAwait(false);

            _stopwatch.Restart();

            return disposable;
        }

        public Task ShowForAsync(Func<CancellationToken, Task> action, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = default)
            => ShowForAsync(action, _options.Value.MinimumTimeframeMs, message, cancelAction, cancellationTokenSource);

        public async Task ShowForAsync(Func<CancellationToken, Task> action, int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            cancellationTokenSource ??= new CancellationTokenSource();

            await using var scope = ShowAsync(loadingTimeMs, message, cancelAction, cancellationTokenSource);

            await action(cancellationTokenSource.Token);
        }

        private ILoadingRenderer CreateRenderer(Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            var factory = _provider.GetRequiredService<LoadingFactory>();
            return factory.CreateLoading()
                .Cancellable(cancelAction != null)
                .WhenClosed(cancelled =>
                {
                    if (cancelled)
                    {
                        cancelAction?.Invoke();
                        cancellationTokenSource?.Cancel();
                    }
                });
        }
    }
}
