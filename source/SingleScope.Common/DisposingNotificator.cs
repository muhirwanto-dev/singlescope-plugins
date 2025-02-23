namespace SingleScope.Common
{
    public class DisposingNotificator : IDisposingNotificator
    {
        private readonly Action _action;

        public DisposingNotificator(Action action)
        {
            _action = action;
        }

        public virtual void Dispose()
        {
            _action.Invoke();
        }
    }

    public class DisposingNotificator<TReturn> : DisposingNotificator, IDisposingNotificator<TReturn>
        where TReturn : class
    {
        public TReturn ReturnValue { get; }

        public DisposingNotificator(TReturn value, Action action)
            : base(action)
        {
            ReturnValue = value;
        }
    }
}
