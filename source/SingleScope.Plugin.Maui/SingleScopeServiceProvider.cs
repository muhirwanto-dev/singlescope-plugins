namespace SingleScope.Plugin.Maui
{
    internal static class SingleScopeServiceProvider
    {
        public static IServiceProvider Current => IPlatformApplication.Current?.Services!;
    }
}
