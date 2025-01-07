namespace SingleScope.Maui.Navigation
{
    public interface IShellNavigationService
    {
        Task PushAsync<TView>(ShellNavigationQueryParameters? query = null) where TView : Page;

        Task PopAsync(ShellNavigationQueryParameters? query = null);

        Task PopToRootAsync<TRoot>(ShellNavigationQueryParameters? query = null) where TRoot : Page;

        void Push<TView>(ShellNavigationQueryParameters? query = null) where TView : Page;

        void Pop(ShellNavigationQueryParameters? query = null);

        void PopToRoot<TRoot>(ShellNavigationQueryParameters? query = null) where TRoot : Page;
    }
}
