using System;

namespace SingleScope.Common.Lifetimes.Abstraction
{
    public interface IDisposableScope : IDisposable
    {
    }

    public interface IDisposableScope<T> : IDisposableScope
    {
        T Context { get; }
    }
}
