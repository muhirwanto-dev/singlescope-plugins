namespace SingleScope.Maui
{
    internal static class SingleScopeServiceProvider
    {
        public static IServiceProvider Current => IPlatformApplication.Current?.Services!;
    }
}
