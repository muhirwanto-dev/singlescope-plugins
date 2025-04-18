namespace SingleScope.Persistence.EFCore
{
    internal static class ServiceLocator
    {
        public static IServiceProvider Provider { get; set; } = default!;
    }
}
