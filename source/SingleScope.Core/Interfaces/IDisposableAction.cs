namespace SingleScope.Core.Interfaces
{
    public interface IDisposableAction : IDisposable
    {
    }

    public interface IDisposableAction<T> : IDisposableAction
    {
        T Owner { get; }
    }
}
