namespace SingleScope.Maui.Navigation
{
    public class ShellNavigationService : IShellNavigationService
    {
        public void Pop(ShellNavigationQueryParameters? query = null)
        {
            _ = PopAsync(query);
        }

        public Task PopAsync(ShellNavigationQueryParameters? query = null)
        {
            return Shell.Current.GoToAsync("..", query);
        }

        public void PopToRoot<TRoot>(ShellNavigationQueryParameters? query = null) where TRoot : Page
        {
            _ = PopToRootAsync<TRoot>(query);
        }

        public Task PopToRootAsync<TRoot>(ShellNavigationQueryParameters? query = null) where TRoot : Page
        {
            return Shell.Current.GoToAsync($"///{nameof(TRoot)}", query);
        }

        public void Push<TView>(ShellNavigationQueryParameters? query = null) where TView : Page
        {
            _ = PushAsync<TView>(query);
        }

        public Task PushAsync<TView>(ShellNavigationQueryParameters? query = null) where TView : Page
        {
            return Shell.Current.GoToAsync(nameof(TView), query);
        }
    }
}
