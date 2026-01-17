using System;

namespace SingleScope.Common.Lifetimes.Abstraction
{
    public interface IAsyncDisposableScope : IAsyncDisposable
    {
    }

    public interface IAsyncDisposableScope<T> : IAsyncDisposableScope
    {
        T Context { get; }
    }
}
