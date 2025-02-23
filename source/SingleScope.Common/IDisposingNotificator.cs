namespace SingleScope.Common
{
    public interface IDisposingNotificator : IDisposable
    {
    }

    public interface IDisposingNotificator<TReturn> : IDisposingNotificator
    {
        TReturn ReturnValue { get; }
    }
}
