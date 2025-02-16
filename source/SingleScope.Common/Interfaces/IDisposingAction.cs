namespace SingleScope.Common.Interfaces
{
    public interface IDisposingAction : IDisposable
    {
    }

    public interface IDisposingAction<T> : IDisposingAction
    {
        T Owner { get; }
    }
}
