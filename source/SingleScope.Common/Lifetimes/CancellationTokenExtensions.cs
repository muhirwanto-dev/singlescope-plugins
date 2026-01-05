using System;
using System.Threading;

namespace SingleScope.Common.Lifetimes
{
    public static class CancellationTokenExtensions
    {
        /// <summary>
        /// Registers a disposable scope to be disposed when the token is cancelled.
        /// </summary>
        public static CancellationTokenRegistration DisposeOnCancel(
            this CancellationToken token,
            IDisposable disposable)
        {
            return token.Register(d => { ((IDisposable)d).Dispose(); }, disposable);
        }

        /// <summary>
        /// Creates a disposable scope tied to cancellation.
        /// </summary>
        public static IDisposable CreateScope(
            this CancellationToken token,
            Action onDispose)
        {
            var scope = DisposableScope.Create(onDispose);
            token.Register(scope.Dispose);
            return scope;
        }
    }
}
