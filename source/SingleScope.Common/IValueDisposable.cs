namespace SingleScope.Common
{
    public interface IValueDisposable : IDisposable
    {
    }

    public interface IValueDisposable<T> : IValueDisposable
    {
        T Value { get; }
    }
}
