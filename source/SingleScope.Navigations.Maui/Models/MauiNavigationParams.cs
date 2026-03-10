using SingleScope.Navigations.Abstractions;

namespace SingleScope.Navigations.Maui.Models
{
    public abstract record MauiNavigationParams : INavigationParams
    {
        public bool Animated { get; init; } = true;
    }
}
