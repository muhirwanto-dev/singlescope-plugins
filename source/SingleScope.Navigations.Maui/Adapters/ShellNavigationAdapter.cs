using Microsoft.Extensions.Options;
using SingleScope.Navigations.Abstractions;
using SingleScope.Navigations.Maui.Models;
using SingleScope.Navigations.Maui.Options;

namespace SingleScope.Navigations.Maui.Adapters
{
    internal sealed class ShellNavigationAdapter(
        IOptions<NavigationOptions> options
        ) : INavigationAdapter
    {
        private static readonly Shell _navigation = Shell.Current;
        private readonly NavigationOptions _options = options.Value;

        public bool CanHandle() => _options.AdapterName == Enums.NavigationAdapterName.Shell
            && Shell.Current is not null;

        public Task BackAsync(CancellationToken cancellationToken = default)
            => BackAsync(ShellNavigationParams.Empty, cancellationToken);

        public Task BackAsync(INavigationParams param, CancellationToken cancellationToken = default)
        {
            var shellParam = GetConcrete(param);

            return _navigation.GoToAsync(shellParam.CombinePath(".."), shellParam.Animated, shellParam.Query);
        }

        public Task NavigateToAsync<TView>(CancellationToken cancellationToken = default)
            => NavigateToAsync<TView>(ShellNavigationParams.Empty, cancellationToken);

        public Task NavigateToAsync<TView>(INavigationParams param, CancellationToken cancellationToken = default)
        {
            var shellParam = GetConcrete(param);

            return _navigation.GoToAsync(shellParam.CombinePath(typeof(TView).Name), shellParam.Animated, shellParam.Query);
        }

        public Task NavigateToRootAsync<TView>(CancellationToken cancellationToken = default)
            => NavigateToRootAsync<TView>(ShellNavigationParams.Empty, cancellationToken);

        public Task NavigateToRootAsync<TView>(INavigationParams param, CancellationToken cancellationToken = default)
        {
            var shellParam = GetConcrete(param);

            if (shellParam.ShellRoute is not ShellNavigationParams.Absolute &&
                shellParam.ShellRoute is not ShellNavigationParams.AbsoluteClearStack)
            {
                shellParam.ShellRoute = ShellNavigationParams.Absolute;
            }

            return _navigation.GoToAsync(shellParam.CombinePath(typeof(TView).Name), shellParam.Animated, shellParam.Query);
        }

        private static ShellNavigationParams GetConcrete(INavigationParams param)
            => param is ShellNavigationParams concrete
             ? concrete
             : throw new InvalidCastException();
    }
}
