namespace SingleScope.Maui.Navigation
{
    public interface IShellNavigationService
    {
        Task PushAsync<TView>() where TView : Page;

        Task PopAsync();

        Task PopToRootAsync<TRootView>() where TRootView : Page;

        Task GoAsync(ShellNavigationState state);

        void Push<TView>() where TView : Page;

        void Pop();

        void PopToRoot<TRootView>() where TRootView : Page;

        void Go(ShellNavigationState state);

        Task PushAsync<TView>(ShellNavigationQueryParameters query) where TView : Page;

        Task PopAsync(ShellNavigationQueryParameters query);

        Task PopToRootAsync<TRootView>(ShellNavigationQueryParameters query) where TRootView : Page;

        Task GoAsync(ShellNavigationState state, ShellNavigationQueryParameters query);

        void Push<TView>(ShellNavigationQueryParameters query) where TView : Page;

        void Pop(ShellNavigationQueryParameters query);

        void PopToRoot<TRootView>(ShellNavigationQueryParameters query) where TRootView : Page;

        void Go(ShellNavigationState state, ShellNavigationQueryParameters query);
    }
}
