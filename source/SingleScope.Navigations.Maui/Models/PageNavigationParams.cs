using SingleScope.Navigations.Maui.Enums;

namespace SingleScope.Navigations.Maui.Models
{
    public sealed record PageNavigationParams : MauiNavigationParams
    {
        public static readonly PageNavigationParams Empty = new();

        public PageNavigationMode Mode { get; init; } = PageNavigationMode.Normal;

        public NavigationQuery Query { get; init; } = [];
    }
}
