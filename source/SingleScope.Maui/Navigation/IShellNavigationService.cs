namespace SingleScope.Maui.Navigation
{
    public interface IShellNavigationService
    {
        Task PushAsync<TView>() where TView : Page;

        Task PopAsync();

        Task PopToRootAsync<TRoot>() where TRoot : Page;

        void Push<TView>() where TView : Page;

        void Pop();

        void PopToRoot<TRoot>() where TRoot : Page;

        Task PushAsync<TView>(ShellNavigationQueryParameters? query) where TView : Page;

        Task PopAsync(ShellNavigationQueryParameters? query);

        Task PopToRootAsync<TRoot>(ShellNavigationQueryParameters? query) where TRoot : Page;

        void Push<TView>(ShellNavigationQueryParameters? query) where TView : Page;

        void Pop(ShellNavigationQueryParameters? query);

        void PopToRoot<TRoot>(ShellNavigationQueryParameters? query) where TRoot : Page;
    }
}
