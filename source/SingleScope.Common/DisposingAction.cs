using SingleScope.Common.Interfaces;

namespace SingleScope.Common
{
    public class DisposingAction : IDisposingAction
    {
        private Action _action;

        public DisposingAction(Action action)
        {
            _action = action;
        }

        public virtual void Dispose()
        {
            _action.Invoke();
        }
    }

    public class DisposingAction<T> : DisposingAction, IDisposingAction<T>
        where T : class
    {
        public T Owner { get; }

        public DisposingAction(T owner, Action action)
            : base(action)
        {
            Owner = owner;
        }
    }
}
