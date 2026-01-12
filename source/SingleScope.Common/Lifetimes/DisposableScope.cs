using System;
using SingleScope.Common.Lifetimes.Abstraction;

namespace SingleScope.Common.Lifetimes
{
    public class DisposableScope : IDisposableScope
    {
        public static readonly DisposableScope Empty = new DisposableScope(() => { }, () => { });

        private readonly Action _onDisposing;
        private readonly Action _onDispose;
        private bool _disposed;

        protected DisposableScope(Action onDispose, Action onDisposing)
        {
            _onDispose = onDispose;
            _onDisposing = onDisposing;
        }

        public static IDisposableScope Create(Action onDispose)
            => new DisposableScope(onDispose, () => { });

        public static IDisposableScope Create(Action onDispose, Action onDisposing)
            => new DisposableScope(onDispose, onDisposing);

        public virtual void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _onDisposing.Invoke();
            }

            _onDispose.Invoke();
            _disposed = true;
        }
    }

    public sealed class DisposableScope<T> : DisposableScope, IDisposableScope<T>
        where T : class
    {
        public T Context { get; }

        private DisposableScope(T context, Action action, Action disposingAction)
            : base(action, disposingAction)
        {
            Context = context;
        }

        public static DisposableScope<T> Create(T context, Action onDispose)
            => new DisposableScope<T>(context, onDispose, () => { });

        public static DisposableScope<T> Create(T context, Action onDispose, Action onDisposing)
            => new DisposableScope<T>(context, onDispose, onDisposing);
    }
}
