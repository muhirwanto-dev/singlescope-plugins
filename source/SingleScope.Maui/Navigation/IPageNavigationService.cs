namespace SingleScope.Maui.Navigation
{
    public interface IPageNavigationService : INavigationService
    {
        INavigation Navigation { get; }

        void InsertPageBefore<TView, TBefore>()
            where TView : Page
            where TBefore : Page;

        void RemovePage<TView>() where TView : Page;
    }
}
