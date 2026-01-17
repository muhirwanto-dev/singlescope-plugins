using System.Diagnostics;
using Microsoft.Extensions.Options;
using SingleScope.Common.Lifetimes;
using SingleScope.Common.Lifetimes.Abstraction;
using SingleScope.Maui.Loadings.Abstractions;
using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Loadings.Core
{
    internal class ProgressiveLoadingService(
        IOptions<ProgressiveLoadingOptions> _options,
        IServiceProvider _provider
        ) : IProgressiveLoadingService
    {
        private readonly Stopwatch _stopwatch = new();

        public IAsyncDisposableScope<IProgressiveLoadingRenderer> ShowAsync(string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
            => ShowAsync(_options.Value.MinimumTimeframeMs, message, cancelAction, cancellationTokenSource);

        public IAsyncDisposableScope<IProgressiveLoadingRenderer> ShowAsync(int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            cancellationTokenSource ??= new CancellationTokenSource();

            var renderer = CreateRenderer(cancelAction, cancellationTokenSource);
            var disposable = AsyncDisposableScope<IProgressiveLoadingRenderer>.Create((IProgressiveLoadingRenderer)renderer, async () =>
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

        public Task ShowForAsync(Func<IProgressiveLoadingRenderer, CancellationToken, Task> action, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
            => ShowForAsync(action, _options.Value.MinimumTimeframeMs, message, cancelAction, cancellationTokenSource);

        public async Task ShowForAsync(Func<IProgressiveLoadingRenderer, CancellationToken, Task> action, int loadingTimeMs, string? message = null, Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            cancellationTokenSource ??= new CancellationTokenSource();

            await using var scope = ShowAsync(loadingTimeMs, message, cancelAction, cancellationTokenSource);

            await action(scope.Context, cancellationTokenSource.Token);
        }

        private ILoadingRenderer CreateRenderer(Action? cancelAction = null, CancellationTokenSource? cancellationTokenSource = null)
        {
            var factory = _provider.GetRequiredService<LoadingFactory>();
            return factory.CreateProgressive()
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
