using SingleScope.Navigations.Abstractions;

namespace SingleScope.Navigations.Maui.Services
{
    internal sealed class MauiNavigationService(
        IEnumerable<INavigationAdapter> _adapters
        ) : INavigationService
    {
        private INavigationAdapter? _availableAdapter => _adapters.FirstOrDefault(x => x.CanHandle());

        public Task BackAsync(CancellationToken cancellationToken = default)
            => _availableAdapter?.BackAsync(cancellationToken)
                ?? Task.CompletedTask;

        public Task BackAsync(INavigationParams param, CancellationToken cancellationToken = default)
            => _availableAdapter?.BackAsync(param, cancellationToken)
                ?? Task.CompletedTask;

        public Task NavigateToAsync<TView>(CancellationToken cancellationToken = default)
            => _availableAdapter?.NavigateToAsync<TView>(cancellationToken)
                ?? Task.CompletedTask;

        public Task NavigateToAsync<TView>(INavigationParams param, CancellationToken cancellationToken = default)
            => _availableAdapter?.NavigateToAsync<TView>(param, cancellationToken)
                ?? Task.CompletedTask;

        public Task NavigateToRootAsync<TView>(CancellationToken cancellationToken = default)
            => _availableAdapter?.NavigateToRootAsync<TView>(cancellationToken)
                ?? Task.CompletedTask;

        public Task NavigateToRootAsync<TView>(INavigationParams param, CancellationToken cancellationToken = default)
            => _availableAdapter?.NavigateToRootAsync<TView>(param, cancellationToken)
                ?? Task.CompletedTask;
    }
}
