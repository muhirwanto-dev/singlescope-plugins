namespace SingleScope.Navigations.Abstractions
{
    public interface INavigationAdapter : INavigationService
    {
        bool CanHandle();
    }
}
