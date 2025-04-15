namespace SingleScope.Common
{
    public class ValueDisposable : IValueDisposable
    {
        public static readonly ValueDisposable Empty = new ValueDisposable(() => { }, () => { });

        private readonly Action _disposingAction;
        private readonly Action _action;

        protected ValueDisposable(Action action, Action disposingAction)
        {
            _action = action;
            _disposingAction = disposingAction;
        }

        public static IValueDisposable Create(Action action)
        {
            return new ValueDisposable(action, () => { });
        }

        public static IValueDisposable Create(Action action, Action disposingAction)
        {
            return new ValueDisposable(action, disposingAction);
        }

        public virtual void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposingAction.Invoke();
            }

            _action.Invoke();
        }
    }

    public sealed class ValueDisposable<T> : ValueDisposable, IValueDisposable<T>
        where T : class
    {
        public T Value { get; }

        private ValueDisposable(T value, Action action, Action disposingAction)
            : base(action, disposingAction)
        {
            Value = value;
        }

        public static IValueDisposable<T> Create(T value, Action action)
        {
            return new ValueDisposable<T>(value, action, () => { });
        }

        public static IValueDisposable<T> Create(T value, Action action, Action disposingAction)
        {
            return new ValueDisposable<T>(value, action, disposingAction);
        }
    }
}
