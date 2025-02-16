namespace SingleScope.Maui
{
    public static class SingleScopeServiceProvider
    {
        public static IServiceProvider Current => IPlatformApplication.Current?.Services!;
    }
}
