using SingleScope.Core.Interfaces;

namespace SingleScope.Core
{
    public class DisposableAction : IDisposableAction
    {
        private Action _action;

        public DisposableAction(Action action)
        {
            _action = action;
        }

        public virtual void Dispose()
        {
            _action.Invoke();
        }
    }

    public class DisposableAction<T> : DisposableAction, IDisposableAction<T>
        where T : class
    {
        public T Owner { get; }

        public DisposableAction(T owner, Action action)
            : base(action)
        {
            Owner = owner;
        }
    }
}
