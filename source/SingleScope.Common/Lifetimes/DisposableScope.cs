using System;
using SingleScope.Common.Lifetimes.Abstraction;

namespace SingleScope.Common.Lifetimes
{
    public class DisposableScope : IDisposableScope
    {
        public static readonly DisposableScope Empty = new DisposableScope(() => { }, () => { });

        private readonly Action _disposingAction;
        private readonly Action _action;

        protected DisposableScope(Action action, Action disposingAction)
        {
            _action = action;
            _disposingAction = disposingAction;
        }

        public static IDisposableScope Create(Action onDispose)
            => new DisposableScope(onDispose, () => { });

        public static IDisposableScope Create(Action onDispose, Action onDisposing)
            => new DisposableScope(onDispose, onDisposing);

        public virtual void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposingAction.Invoke();
            }

            _action.Invoke();
        }
    }

    public sealed class DisposableScope<T> : DisposableScope, IDisposableScope<T>
        where T : class
    {
        public T Value { get; }

        private DisposableScope(T value, Action action, Action disposingAction)
            : base(action, disposingAction)
        {
            Value = value;
        }

        public static DisposableScope<T> Create(T value, Action onDispose)
            => new DisposableScope<T>(value, onDispose, () => { });

        public static DisposableScope<T> Create(T value, Action onDispose, Action onDisposing)
            => new DisposableScope<T>(value, onDispose, onDisposing);
    }
}
