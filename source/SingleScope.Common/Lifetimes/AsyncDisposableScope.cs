using System;
using System.Threading.Tasks;
using SingleScope.Common.Lifetimes.Abstraction;

namespace SingleScope.Common.Lifetimes
{
    public class AsyncDisposableScope : IAsyncDisposableScope
    {
        public static readonly AsyncDisposableScope Empty = new AsyncDisposableScope(() => Task.CompletedTask, () => Task.CompletedTask);

        private readonly Func<Task> _onDisposing;
        private readonly Func<Task> _onDispose;
        private bool _disposed;

        protected AsyncDisposableScope(Func<Task> onDispose, Func<Task> onDisposing)
        {
            _onDispose = onDispose;
            _onDisposing = onDisposing;
        }

        public static IAsyncDisposableScope Create(Func<Task> onDispose)
            => new AsyncDisposableScope(onDispose, () => Task.CompletedTask);

        public static IAsyncDisposableScope Create(Func<Task> onDispose, Func<Task> onDisposing)
            => new AsyncDisposableScope(onDispose, onDisposing);

        public virtual ValueTask DisposeAsync() => DisposeAsync(true);

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                await _onDisposing.Invoke();
            }

            await _onDispose.Invoke();
            _disposed = true;
        }
    }

    public sealed class AsyncDisposableScope<T> : AsyncDisposableScope, IAsyncDisposableScope<T>
        where T : class
    {
        public T Context { get; }

        private AsyncDisposableScope(T context, Func<Task> action, Func<Task> disposingAction)
            : base(action, disposingAction)
        {
            Context = context;
        }

        public static AsyncDisposableScope<T> Create(T context, Func<Task> onDispose)
            => new AsyncDisposableScope<T>(context, onDispose, () => Task.CompletedTask);

        public static AsyncDisposableScope<T> Create(T context, Func<Task> onDispose, Func<Task> onDisposing)
            => new AsyncDisposableScope<T>(context, onDispose, onDisposing);
    }
}
