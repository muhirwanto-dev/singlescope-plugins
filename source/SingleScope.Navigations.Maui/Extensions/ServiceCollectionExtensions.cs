using Microsoft.Extensions.DependencyInjection.Extensions;
using SingleScope.Navigations.Abstractions;
using SingleScope.Navigations.Maui.Adapters;
using SingleScope.Navigations.Maui.Options;
using SingleScope.Navigations.Maui.Services;

namespace SingleScope.Navigations.Maui.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers SingleScope MAUI navigation services.
        /// </summary>
        public static IServiceCollection AddSingleScopeNavigations(
            this IServiceCollection services)
            => services.AddSingleScopeNavigations(opt => { });

        public static IServiceCollection AddSingleScopeNavigations(
            this IServiceCollection services, Action<NavigationOptions> configuration)
        {
            services.Configure(configuration);

            // Navigation adapters
            services.AddSingleton<INavigationAdapter, ShellNavigationAdapter>();
            services.AddSingleton<INavigationAdapter, PageNavigationAdapter>();

            // Core navigation services
            services.TryAddSingleton<INavigationService, MauiNavigationService>();

            return services;
        }
    }
}
