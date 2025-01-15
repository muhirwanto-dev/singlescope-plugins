namespace SingleScope.Maui.Navigation
{
    public interface INavigationService
    {
        Task PushAsync<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page;

        Task PushModalAsync<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page;

        Task<TView?> PopAsync<TView>() where TView : Page;

        Task<TView?> PopModalAsync<TView>() where TView : Page;

        Task PopToRootAsync(bool animated = true);

        void Push<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page;

        void PushModal<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page;

        void Pop<TView>() where TView : Page;

        void PopModal<TView>() where TView : Page;

        void PopToRoot(bool animated = true);

        void InsertPageBefore<TView, TBefore>()
            where TView : Page
            where TBefore : Page;

        void RemovePage<TView>() where TView : Page;
    }
}
